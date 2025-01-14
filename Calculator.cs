using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using ComboBox = System.Windows.Forms.ComboBox;

namespace HBOCalculator
{
    public partial class Calculator : Form
    {

        string[] formats = { "HH:mm", "H:mm", "HHmm" }; //value can be one of these formats
        public Calculator()
        {
            InitializeComponent();
            Console.WriteLine("Hello World");
            //DiveTableGridView.Rows.Add("", "", "", "", "", "", "", "", "", "");
            //DiveTableGridView.Rows.Add("", "", "", "", "", "", "", "", "", "");
            //DiveTableGridView.Rows[0].HeaderCell.Value = "Chamber Pressure";
            //DiveTableGridView.Rows[1].HeaderCell.Value = "Clock Time (24 hr)";
            //DiveTableGridView.Rows.Add("", "", "", "", "", "", "", "", "", "");
            //DiveTableGridView.Rows.Add("", "", "", "", "", "", "", "", "", "");
            //DiveTableGridView.Rows[0].HeaderCell.Value = "Chamber Pressure";
            //DiveTableGridView.Rows[1].HeaderCell.Value = "Clock Time (24 hr)";
            //DiveTableGridView.RowHeadersWidth = 100;
            //DiveTableGridView.RowHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlDark;
            //DiveTableGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlDark;
            DiveTableGridView.Rows.Add("1 ATA", "", "", "", "", "", "", "", "", "1 ATA");
            DiveTableGridView.Rows.Add("", "", "", "", "", "", "", "", "", "");
            DiveTableGridView.Rows[0].HeaderCell.Value = "Chamber Pressure";
            DiveTableGridView.Rows[1].HeaderCell.Value = "Clock Time (24 hr)";
            //DiveTableGridView.Rows[1].Cells[2].Value = "0";
            //DiveTableGridView.Columns[3].HeaderCell.
            //DiveTableGridView.RowHeadersWidth = 100;
            //DiveTableGridView.RowHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlDark;
            //DiveTableGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlDark;


            DiveTableGridView.CellValidating += DiveTableGridView_CellValidating;

            DiveRateDownComboBox.SelectedIndexChanged += ComponentChanged;
            DiveRateDownComboBox.TextChanged += ComponentChanged;
            DiveRateUpComboBox.SelectedIndexChanged += ComponentChanged;
            DiveRateUpComboBox.TextChanged += ComponentChanged;
            ATATextBox.TextChanged += ComponentChanged;
            minWOxygenTextBox.TextChanged += ComponentChanged;
            numAirBreaksTextBox.TextChanged += ComponentChanged;
            lengthAirBreaksTextBox.TextChanged += ComponentChanged;
            DiveTableGridView.CellValueChanged += DataGridViewCellChanged;
            resetButton.Click += resetButton_Click;

            ATATextBox.Validating += TextBox_Validating;
            minWOxygenTextBox.Validating += TextBox_Validating;
            numAirBreaksTextBox.Validating += TextBox_Validating;
            lengthAirBreaksTextBox.Validating += TextBox_Validating;
            DiveRateDownComboBox.Validating += ComboBox_Validating;
            DiveRateUpComboBox.Validating += ComboBox_Validating;
        }


        private void ComponentChanged(object sender, EventArgs e)
        {
            //CalculateDiveTable();
            canCalculate();
        }

        private void DataGridViewCellChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Trigger Calculate() only for Row 1, Cell 0 (Start time Update)
            if (e.RowIndex == 1 && e.ColumnIndex == 0)
            {
                //CalculateDiveTable();
                canCalculate();
            }
        }

        private void TreatmentProtocolComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string optionSelected = TreatmentProtocolComboBox.SelectedItem.ToString();
            Console.WriteLine(optionSelected);
            int treatmentLength;

            switch (optionSelected)
            {
                case "2.0 ATA x 90 min w/ 100% oxygen, and no air breaks":
                    treatmentLength = 90;
                    break;
                case "2.4 ATA x 90 min w/ 100% oxygen, and two 5 minute air breaks":
                    treatmentLength = 100;
                    break;
                default:
                    treatmentLength = 0;
                    break;
            }

            TreatmentLengthTextbox.Text = treatmentLength.ToString();
        }

        private void ComboBox_Validating(object sender, CancelEventArgs e)
        {
            
            if(!double.TryParse((sender as System.Windows.Forms.ComboBox).Text, out _))
            {
                ATAErrorProvider.SetError((sender as System.Windows.Forms.ComboBox), "Please enter a valid decimal number");
            }
            else
            {
                ATAErrorProvider.SetError((sender as System.Windows.Forms.ComboBox), string.Empty);
            }
        }


        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            //validate textboxes as double or int based on which textbox it is
            if ((sender as System.Windows.Forms.TextBox).Name == "ATATextBox")
            {
                if (!double.TryParse((sender as System.Windows.Forms.TextBox).Text, out _))
                {
                    e.Cancel = true;
                    ATAErrorProvider.SetError((sender as System.Windows.Forms.TextBox), "Please enter a valid decimal number");
                }
                else
                {
                    ATAErrorProvider.SetError((sender as System.Windows.Forms.TextBox), string.Empty);
                }
            }
            else
            {
                if (!int.TryParse((sender as System.Windows.Forms.TextBox).Text, out _))
                {
                    e.Cancel = true;
                    ATAErrorProvider.SetError((sender as System.Windows.Forms.TextBox), "Please enter a valid whole number");
                }
                else
                {
                    ATAErrorProvider.SetError((sender as System.Windows.Forms.TextBox), string.Empty);
                }
            }
        }

        private void canCalculate()
        {
            //flag for validation of required fields
            bool canCalculate = true;


            //validate the treatment protocol combobox
            if (string.IsNullOrEmpty(ATATextBox.Text) || !double.TryParse(ATATextBox.Text, out _))
            {
                //TreatmentProtocolErrorProvider.SetError(TreatmentProtocolComboBox, "Please select or enter a value.");
                //ATATextBoxErrorMessage.Visible = true;
                canCalculate = false;
                return; //return if error validates to true so it only shows one error at a time
            }
            else
            {
                //ATATextBoxErrorMessage.Visible = false; //remove error message if input is valid
            }

            //validate the treatment protocol combobox
            if (string.IsNullOrEmpty(minWOxygenTextBox.Text) || !int.TryParse(minWOxygenTextBox.Text, out _))
            {
                //TreatmentProtocolErrorProvider.SetError(TreatmentProtocolComboBox, "Please select or enter a value.");
                //minWOxygenTextBoxErrorMessage.Visible = true;
                canCalculate = false;
                return; //return if error validates to true so it only shows one error at a time
            }
            else
            {
                //minWOxygenTextBoxErrorMessage.Visible = false; //remove error message if input is valid
            }

            //validate the treatment protocol combobox
            if (string.IsNullOrEmpty(numAirBreaksTextBox.Text) || !int.TryParse(numAirBreaksTextBox.Text, out _))
            {
                //TreatmentProtocolErrorProvider.SetError(TreatmentProtocolComboBox, "Please select or enter a value.");
                //numAirBreaksTextBoxErrorMessage.Visible = true;
                canCalculate = false;
                return; //return if error validates to true so it only shows one error at a time
            }
            else
            {
                //numAirBreaksTextBoxErrorMessage.Visible = false; //remove error message if input is valid
            }

            //validate the treatment protocol combobox
            if (string.IsNullOrEmpty(lengthAirBreaksTextBox.Text) || !int.TryParse(lengthAirBreaksTextBox.Text, out _))
            {
                //TreatmentProtocolErrorProvider.SetError(TreatmentProtocolComboBox, "Please select or enter a value.");
                //lengthAirBreaksTextBoxErrorMessage.Visible = true;
                canCalculate = false;
                return; //return if error validates to true so it only shows one error at a time
            }
            else
            {
                //lengthAirBreaksTextBoxErrorMessage.Visible = false; //remove error message if input is valid
            }

            //valdiate dive rate down combo box
            if (string.IsNullOrEmpty(DiveRateDownComboBox.Text) || !double.TryParse(DiveRateDownComboBox.Text, out _))
            {
                //DiveRateDownErrorMessage.Visible = true;
                canCalculate = false;
                return;
            }
            else
            {
                //DiveRateDownErrorMessage.Visible = false;
            }

            //validate dive rate up combo box
            if (string.IsNullOrEmpty(DiveRateUpComboBox.Text) || !double.TryParse(DiveRateUpComboBox.Text, out _))
            {
                //DiveRateUpErrorMessage.Visible = true;
                canCalculate = false;
                return;
            }
            else
            {
                //DiveRateUpErrorMessage.Visible = false;
            }


            //validate that there is a start time
            if (string.IsNullOrEmpty(DiveTableGridView.Rows[1].Cells[0].Value.ToString()) && canCalculate)
            {
                CompressBeginTimeErrorMessage.Visible = true;
                canCalculate = false;
                return;
            }
            else
            {
                CompressBeginTimeErrorMessage.Visible = false;
            }


            //return canCalculate;
            if (canCalculate)
            {
                CalculateDiveTable();
            }
            else
            {
                MessageBox.Show("Could not calculate, please try again later.", "System Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private double calculateMinutesDownOrUp(double ataStart, double ataEnd, double diveRate)
        {
            //****Find the minutes down/up******//

            double startingPSI = 15 * ataStart;
            double endPSI = 15 * ataEnd; //if ATA is 2, should have PSI of 30
            double time = (endPSI - startingPSI) / diveRate; //gets the number of minutes diving down/up to the specified PSI at that rate
            time = Math.Round(time, 1); //rounds to 1 decimal place ex: 7.5

            return time;
        }

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

            DateTime startTime = pressureReachedTime.AddMinutes(minutesToAdd);

            return startTime;
        }


        private void calculateButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("clicked");
        }
        private void CalculateDiveTable()
        {
            //test logic for if 
            //if (canCalculate())
            //{
                //calculateButton.BackColor = Color.Green;


                //CLEAR PREVIOUS ENTRIES
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

                //get treatment length
                TimeSpan treatmentLength = decompressEndTime - beganAt;

                TreatmentLengthTextbox.Text = Math.Floor(treatmentLength.TotalMinutes).ToString();

            //}
        }

        private void DiveTableGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DateTime value; //saves value when parsing to convert it to one universal value


            //bottom row cell edits must either be a 24 hour time format or empty
            if (e.RowIndex == 1) //Top row must be Strings

                //if it doesn't match the global time formats AND it is not null 
                if (!DateTime.TryParseExact(e.FormattedValue.ToString(), formats, null, System.Globalization.DateTimeStyles.None, out value) && !string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {

                    //cancel the edit and show the error
                    e.Cancel = true;
                    DiveTableGridView.Rows[e.RowIndex].ErrorText = "Please enter a valid 24-hour time (HH:mm).";
                }
                else
                {
                    //clear error if valid
                    DiveTableGridView.Rows[e.RowIndex].ErrorText = string.Empty;

                    //change value to HH:mm once validated if there is a value in the box

                    /* NOTE:
                     * the cell value is not converted until after the cell is validated, however, canCalculate is called as soon as cell is changed in DataGridViewCellChanged()
                     * that means that when calculateDiveTable is called, it is not necessarily this format that it will see, it may be HHmm or H:mm depending on what is inputted
                     * if you want calculateDiveTable to parse only this format below, canCalculate must be called from this function rather than DataGridViewCellChanged()
                     * as of right now, this only changes for aesthetic purposes to keep everything clean and of the same format in the table, not so that this is the value that is parsed
                     */
                    if (!string.IsNullOrEmpty(e.FormattedValue.ToString()) ) 
                    { 
                        DiveTableGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value.ToString("HH:mm"); 
                    }
                }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            TreatmentLabelTextbox.Text = string.Empty;
            TreatmentLengthTextbox.Text = string.Empty;
            ATATextBox.Text = string.Empty;
            minWOxygenTextBox.Text = string.Empty;
            numAirBreaksTextBox.Text = string.Empty;
            lengthAirBreaksTextBox.Text = string.Empty;
            DiveRateDownComboBox.Text = string.Empty;
            DiveRateUpComboBox.Text = string.Empty;


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

    }

}
