using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace HBOCalculator
{
    public partial class Calculator : Form
    {

        string[] formats = { "HH:mm", "H:mm", "HHmm" }; //valid formats for time input (all 24hr) ex: 09:00 OR 9:00 OR 0900
        public Calculator()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.EnableAllowFocusChange; //allows user to click into other boxes even if the focused control has invalid data

            //add key handler events to detect return key and move to next control
            this.PreviewKeyDown += new PreviewKeyDownEventHandler(Control_PreviewKeyDown);
            this.KeyDown += new KeyEventHandler(Control_KeyDown);
                
            //initializes data table
            DiveTableGridView.Rows.Add("1 ATA", "", "", "", "", "", "", "", "", "1 ATA");
            DiveTableGridView.Rows.Add("", "", "", "", "", "", "", "", "", "");
            DiveTableGridView.Rows[0].HeaderCell.Value = "Chamber Pressure";
            DiveTableGridView.Rows[1].HeaderCell.Value = "Clock Time (24 hr)";
            

            //subscribes datagridview to the validating functionality
            DiveTableGridView.CellValidating += DiveTableGridView_CellValidating;

            //subscribe the clear button to the functionality
            resetButton.Click += resetButton_Click;

            //subscribe form to form closing function to stop errors from inhibiting the ability to close the application
            this.FormClosing += Calculator_FormClosing;

            //subscribe control boxes to the component changed event to track changes made
            ATATextBox.TextChanged += ComponentChanged;
            minWOxygenTextBox.TextChanged += ComponentChanged;
            numAirBreaksTextBox.TextChanged += ComponentChanged;
            lengthAirBreaksTextBox.TextChanged += ComponentChanged;
            DiveRateDownComboBox.TextChanged += ComponentChanged;
            DiveRateUpComboBox.TextChanged += ComponentChanged;
            DiveRateDownComboBox.SelectionChangeCommitted += ComponentChanged;
            DiveRateUpComboBox.SelectionChangeCommitted += ComponentChanged;




        }


        //function to track when input boxes are changed 
        private void ComponentChanged(object sender, EventArgs e)
        {

            CancelEventArgs cancelEventArgs = new CancelEventArgs(); //creates a cancelEventArgs to send to validating functions

            //call the appropriate validating function based on the type of the control
            if((sender is System.Windows.Forms.ComboBox))
            {
                ComboBox_Validating(sender, cancelEventArgs);
            }
            else if (sender is System.Windows.Forms.TextBox)
            {
                TextBox_Validating(sender, cancelEventArgs);
            }
        }

        //Funtion to validate combo box controls (diverate up and diverate down are the only 2, they require doubles)
        private void ComboBox_Validating(object sender, CancelEventArgs e)
        {
            
            //if the value in the combo box is not a decimal number, cancel the event and set an error
            if (!double.TryParse((sender as System.Windows.Forms.ComboBox).Text, out _))
            {
                e.Cancel = true;
                ATAErrorProvider.SetError((sender as System.Windows.Forms.ComboBox), "Please enter a valid decimal number");
            }
            else
            {
                ATAErrorProvider.SetError((sender as System.Windows.Forms.ComboBox), string.Empty); //remove the error if any
                canCalculate();
            }
        }


        //function to validate textbox controls
        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
           
            //validate textboxes as double or int based on which textbox it is
            if ((sender as System.Windows.Forms.TextBox).Name == "ATATextBox") //atatextbox can be double as well asint
            {
                if (!double.TryParse((sender as System.Windows.Forms.TextBox).Text, out _)) //check if it is a valid decimal (ata can be 2.4)
                {
                    e.Cancel = true;
                    ATAErrorProvider.SetError((sender as System.Windows.Forms.TextBox), "Please enter a valid decimal number");
                }
                else
                {
                    ATAErrorProvider.SetError((sender as System.Windows.Forms.TextBox), string.Empty);
                    canCalculate(); //call calculate with change in atatextbox available
                }
            }
            else //if it is a textbox other than ata textbox it can only have integers
            {
                if (!int.TryParse((sender as System.Windows.Forms.TextBox).Text, out _)) //check if it is a valid integer
                {
                    e.Cancel = true;
                    ATAErrorProvider.SetError((sender as System.Windows.Forms.TextBox), "Please enter a valid whole number");
                }
                //limit the amount of breaks to 3 maximum after checking if it is a valid integer
                else if((sender as System.Windows.Forms.TextBox).Name == "numAirBreaksTextBox" && int.Parse((sender as System.Windows.Forms.TextBox).Text) > 3)
                {
                    e.Cancel = true;
                    ATAErrorProvider.SetError((sender as System.Windows.Forms.TextBox), "Maximum of 3 air breaks.");
                }
                else //if everything passed
                {
                    ATAErrorProvider.SetError((sender as System.Windows.Forms.TextBox), string.Empty);
                    canCalculate(); //call calculate
                }
            }
        }

        //function to validate cell changes in data table
        private void DiveTableGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DateTime value; //stores the out value when parsing to convert it to one universal format


            //bottom row cell edits must either be a 24 hour time format or empty
            if (e.RowIndex == 1)
            {

                //if the entered start time matchs the global time formats or it is empty (it's ok for it to be null bc canCalculate will catch it )
                if (DateTime.TryParseExact(e.FormattedValue.ToString(), formats, null, System.Globalization.DateTimeStyles.None, out value) || string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {

                    DiveTableGridView.Rows[e.RowIndex].ErrorText = string.Empty; //clear error if any

                    //commit the changes so that they are available when calling canCalculate
                    DiveTableGridView.CommitEdit(DataGridViewDataErrorContexts.Commit); //note: this is necessary, otherwise value of the cell will be an empty string and will have to hit enter/tab 2x for it to register

                    //convert to proper string format if it is not empty
                    if (!string.IsNullOrEmpty(e.FormattedValue.ToString()))
                    {
                        DiveTableGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value.ToString("HH:mm");
                    }

                    canCalculate();
                
                }
                else
                {
                    //cancel the edit and show the error
                    e.Cancel = true;
                    DiveTableGridView.Rows[e.RowIndex].ErrorText = "Please enter a valid 24-hour time (HH:mm).";
                }
            }
        }


        //used to make sure EVERY field that is needed for calculation has a valid value. 
        private void canCalculate()
        {
            //flag for validation of required fields
            bool canCalculate = true;

            /*MARK validate inputs. Returns if validation failed so that the final conditional checking the value of canCalculate does not run prematurely*/

            //make sure that ata textbox is a valid double or that there is no error attached
            if ((string.IsNullOrEmpty(ATATextBox.Text) || !double.TryParse(ATATextBox.Text, out _)) || ATAErrorProvider.GetError(ATATextBox) != string.Empty)
            {
                canCalculate = false;
                return; 
            }

            //make sure that textbox is a valid int or that there is no error attached
            if ((string.IsNullOrEmpty(minWOxygenTextBox.Text) || !int.TryParse(minWOxygenTextBox.Text, out _)) || ATAErrorProvider.GetError(minWOxygenTextBox) != string.Empty)
            {

                canCalculate = false;
                return; 
            }


            //make sure that textbox is a valid int, that it is not greater than 3 breaks or that there is no error attached
            if ((string.IsNullOrEmpty(numAirBreaksTextBox.Text) || !int.TryParse(numAirBreaksTextBox.Text, out _) || int.Parse(numAirBreaksTextBox.Text) > 3) || ATAErrorProvider.GetError(numAirBreaksTextBox) != string.Empty)
            {
                canCalculate = false;
                return; 
            }


            //make sure that textbox is a valid int or that there is no error attached
            if ((string.IsNullOrEmpty(lengthAirBreaksTextBox.Text) || !int.TryParse(lengthAirBreaksTextBox.Text, out _)) || ATAErrorProvider.GetError(lengthAirBreaksTextBox) != string.Empty)
            {
                //TreatmentProtocolErrorProvider.SetError(TreatmentProtocolComboBox, "Please select or enter a value.");
                //lengthAirBreaksTextBoxErrorMessage.Visible = true;
                canCalculate = false;
                return; 
            }

            //make sure that combobox is a valid double or that there is no error attached
            if ((string.IsNullOrEmpty(DiveRateDownComboBox.Text) || !double.TryParse(DiveRateDownComboBox.Text, out _)) || ATAErrorProvider.GetError(DiveRateDownComboBox) != string.Empty)
            {
                //DiveRateDownErrorMessage.Visible = true;
                canCalculate = false;
                return; 
            }

            //make sure that combobox is a valid double or that there is no error attached
            if ((string.IsNullOrEmpty(DiveRateUpComboBox.Text) || !double.TryParse(DiveRateUpComboBox.Text, out _)) || ATAErrorProvider.GetError(DiveRateUpComboBox) != string.Empty)
            {
                //DiveRateUpErrorMessage.Visible = true;
                canCalculate = false;
                return;
            }


            //if there is no start time & canCalculate is true (meaning every other input is filled out), then display error message to enter start time
            if (string.IsNullOrEmpty(DiveTableGridView.Rows[1].Cells[0].Value.ToString()) && canCalculate)
            {
                CompressBeginTimeErrorMessage.Visible = true;
                canCalculate = false;
                return;
            }
            else
            {
                CompressBeginTimeErrorMessage.Visible = false; //remove error message if any
            }


            //check the final value of canCalculate, if everything passed than begin calculations, if somehow it got to this point with all the returns then call an error
            if (canCalculate)
            {
                CalculateDiveTable();
            }
            else
            {
                MessageBox.Show("Could not calculate, please try again later.", "System Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }


        //function to find the time in minutes for compression or decompression
        private double calculateMinutesDownOrUp(double ataStart, double ataEnd, double diveRate)
        {
            //****Find the minutes down/up******//

            double startingPSI = 15 * ataStart;
            double endPSI = 15 * ataEnd; //if ATA is 2, should have PSI of 30
            double time = (endPSI - startingPSI) / diveRate; //gets the number of minutes diving down/up to the specified PSI at that rate
            time = Math.Round(time, 1); //rounds to 1 decimal place ex: 7.5

            return time;
        }

        //function to programmatically calculate the time of the specified break (n)
        private DateTime calculateStartTime(DateTime pressureReachedTime, int n, int numOfBreaks, int lengthOfBreaks,
            int protocolLength)
        {
            //get number of breathing periods (just one more than number of breaks)
            int numOfBreathingPeriods = numOfBreaks + 1;

            //calculate minutes per breathing period
            int lengthOfBreathingPeriods = protocolLength / numOfBreathingPeriods;

            /* BREAKDOWN OF FORMULA BELOW:
           
             * n breathing periods * breathing period minutes = Adding the accumulation of breathing periods before break n
                 - if you're at break (n)umber2, there's been 2 breathing periods

             * n-1 breaks * break minutes = Adding the accumulation of breaks before n
                 - if you're at break (n)umber 2, there's been 1 break before you
            
             * Add length of breathing periods and length of breaks to the time the dive reached depth to get start time for n 
            
            */

            //calculate start time of specified break (n)
            int minutesToAdd = (n * lengthOfBreathingPeriods) + ((n - 1) * lengthOfBreaks);

            DateTime breakStartTime = pressureReachedTime.AddMinutes(minutesToAdd);

            return breakStartTime;
        }

        
        //function to actually calculate and fill out each cell of the dive table
        private void CalculateDiveTable()
        {

                //CLEAR PREVIOUS ENTRIES each time calculate is called
                for (int row = 0; row < DiveTableGridView.Rows.Count; row++)
                {
                    for (int col = 0; col < DiveTableGridView.Columns.Count; col++)
                    {
                        //skip static 1ATA cells and user input time cell
                        if ((row == 0 && col == 0) || (row == 1 && col == 0) || (row == 0 && col == 9))
                        {
                            continue;
                        }
                        else //clear the rest
                        {
                            DiveTableGridView.Rows[row].Cells[col].Value = null;
                        }
                    }
                }

                //****Find the minutes down******//
                double startATA = 1; //starting ATA is always 1
                double endATA = double.Parse(ATATextBox.Text); //VALIDATE THIS!!!
                double diveRateDown = double.Parse(DiveRateDownComboBox.Text); //VALIDATE THIS!!!
                double diveRateUp = double.Parse(DiveRateUpComboBox.Text); //VALIDATE THIS!!!

                double minutesDown = calculateMinutesDownOrUp(startATA, endATA, diveRateDown); //minutes from 1 ATA to at depth
                double minutesUp = Math.Abs(calculateMinutesDownOrUp(endATA, startATA, diveRateUp));//minutes from at depth to normal 

                
                DateTime beganAt = DateTime.ParseExact(DiveTableGridView.Rows[1].Cells[0].Value.ToString(), formats, null, DateTimeStyles.None); //get userinputted start time
                DateTime pressureReached = beganAt.AddMinutes(minutesDown); //add minutes down to start time

                string atDepthStart = pressureReached.ToString("HH:mm"); //convert to time string

                DiveTableGridView.Rows[1].Cells[1].Value = atDepthStart; //add time of depth reached to table
                DiveTableGridView.Rows[1].Cells[0].Value = beganAt.ToString("HH:mm"); //convert whatever format it came in to the uniform HH:mm format 


                //fill out TX Pressure Reached and Decompress Begins ATA 
                string ata = ATATextBox.Text; //get treatment protocol ata

                DiveTableGridView.Rows[0].Cells[1].Value = ata + " ATA";
                DiveTableGridView.Rows[0].Cells[8].Value = ata + " ATA";

                //from cells 2-7 in row 0 (Air breaks), fill out ata if the air breaks exist
                int numAirBreaks = int.Parse(numAirBreaksTextBox.Text);
                int protocolLength = int.Parse(minWOxygenTextBox.Text);
                int airbreakLength = int.Parse(lengthAirBreaksTextBox.Text);


                //if 1 air break, cells 2 and 3 are filled
                //if 2 air breaks, cells 4 and 5 are filled
                //if 3 air breaks, cells 6 and 7 are filled

                int i = 1; //if 0 air breaks nothing is filled out

                //fill out airbreak and breathing period slots
                while (i <= numAirBreaks && i <= 3) //there are spots for only 3 air breaks, anything past 3 is ignored
                {
                    DiveTableGridView.Rows[0].Cells[i + i].Value = ata + " ATA";
                    DiveTableGridView.Rows[0].Cells[i + i + 1].Value = ata + " ATA";


                    DateTime airbreakStart = calculateStartTime(pressureReached, i, numAirBreaks, airbreakLength, protocolLength);

                    //air break start time from calculation
                    DiveTableGridView.Rows[1].Cells[i + i].Value = airbreakStart.ToString("HH:mm");

                    //airbreak end time is just start time plus length of break
                    DiveTableGridView.Rows[1].Cells[i + i + 1].Value = airbreakStart.AddMinutes(airbreakLength).ToString("HH:mm");

                    i++;

                }

                //calculate start time of decompress, n is number of breaks + 1 to add up total breathing period and air break times
                DateTime decompressBeginTime = calculateStartTime(pressureReached, numAirBreaks + 1, numAirBreaks, airbreakLength, protocolLength);
                DiveTableGridView.Rows[1].Cells[8].Value = decompressBeginTime.ToString("HH:mm");

                //minutes up already calculated, add to decompress begin to find decompress end
                DateTime decompressEndTime = decompressBeginTime.AddMinutes(minutesUp);
                DiveTableGridView.Rows[1].Cells[9].Value = decompressEndTime.ToString("HH:mm");

                //get treatment length and display it
                TimeSpan treatmentLength = decompressEndTime - beganAt;

                TreatmentLengthTextbox.Text = Math.Floor(treatmentLength.TotalMinutes).ToString();

            
        }

        //function to clear all input and fields when clear button is clicked
        private void resetButton_Click(object sender, EventArgs e)
        {

            //clear all field values
            TreatmentLabelTextbox.Text = string.Empty;
            TreatmentLengthTextbox.Text = string.Empty;
            ATATextBox.Text = string.Empty;
            minWOxygenTextBox.Text = string.Empty;
            numAirBreaksTextBox.Text = string.Empty;
            lengthAirBreaksTextBox.Text = string.Empty;
            DiveRateDownComboBox.Text = string.Empty;
            DiveRateUpComboBox.Text = string.Empty;

            //clears error messages
            ATAErrorProvider.Clear();
            CompressBeginTimeErrorMessage.Visible = false;

            //clears data grid view
            for (int row = 0; row < DiveTableGridView.Rows.Count; row++)
            {
                for (int col = 0; col < DiveTableGridView.Columns.Count; col++)
                //f
                {
                    //skip static 1ATA cells and user input time cell
                    if ((row == 0 && col == 0) || (row == 0 && col == 9))
                    {
                        continue;
                    }
                    else //clear the rest
                    {
                        DiveTableGridView.Rows[row].Cells[col].Value = "";
                    }
                }
            }
        }

        //runs when the form is being closed (x button is pressed and application is exited)
        private void Calculator_FormClosing(object sender, FormClosingEventArgs e)
        {
            //prevents errors from cancelling the close event. form can be closed whether or not there is invalid data
            e.Cancel = false;
        }

        //function to preview the key, only used to set return(enter) as an input key so that it can raise the keydown event
        private void Control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true; 
            }
        }

        //function to activate the next control in the tab order when the enter key is pressed. 
        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Control ctl = (Control)sender;
                ctl.SelectNextControl(ActiveControl, true, true, true, true); //active control gets the currently active control in the container control
                e.SuppressKeyPress = true; //used so that windows "bell" sound does not occur on press
            }
        }

    }

}