using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecCardDoor
{
    public partial class SecurityForm : Form
    {
        public SecurityForm()
        {
            InitializeComponent();
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            LowCard cardLow = new LowCard();
            MediumCard cardMed = new MediumCard();
            HighCard cardHigh = new HighCard();

            LowDoor doorLow = new LowDoor();
            MediumDoor doorMed = new MediumDoor();
            HighDoor doorHigh = new HighDoor();

            if (cardLevelBox.SelectedIndex != -1 && doorLevelBox.SelectedIndex != -1)
            {
                string cardLevel = cardLevelBox.SelectedItem.ToString();
                string doorLevel = doorLevelBox.SelectedItem.ToString();
                bool validSecCheck = true;

                if (doorLevel == "Low")
                {
                    if (cardLevel == "Low")
                    {
                        doorLow.Accept(cardLow);
                        cardLow.Enter(doorLow);
                    }
                    else if (cardLevel == "Medium")
                    {
                        doorLow.Accept(cardMed);
                        cardMed.Enter(doorLow);
                    }
                    else if (cardLevel == "High")
                    {
                        doorLow.Accept(cardHigh);
                        cardHigh.Enter(doorLow);
                    }
                }
                else if (cardLevel == "High")
                {
                    if (doorLevel == "Medium")
                    {
                        doorMed.Accept(cardHigh);
                        cardHigh.Enter(doorMed);
                    }
                    else if (doorLevel == "High")
                    {
                        doorHigh.Accept(cardHigh);
                        cardHigh.Enter(doorHigh);
                    }
                }
                else if (cardLevel == "Medium" && doorLevel == "Medium")
                {
                    doorMed.Accept(cardMed);
                    cardMed.Enter(doorMed);
                }
                else
                {
                    /* 
                     * The following combinations do not compile:
                     * doorHigh.Accept(cardMed);
                     * cardMed.Enter(doorHigh);
                     * 
                     * doorHigh.Accept(cardLow);
                     * cardLow.Enter(doorHigh);
                     * 
                     * doorMed.Accept(cardLow);
                     * cardLow.Enter(doorMed);
                     */
                    validSecCheck = false;
                }
                confirmMessage(cardLevel, doorLevel, validSecCheck);
            }
        }

        private void confirmMessage(string card_Level, string door_Level, bool success)
        {
            string card_data = "Your security level is " + card_Level;
            string door_data = "Security level of the door is " + door_Level;
            string entry = "You can enter this door";
            string victory = "Success!";
            if (!success)
            {
                entry = "You do not have the security clearance to enter this door.";
                victory = "Error";
            }
            MessageBox.Show(card_data + "\n" + door_data + "\n" + entry, victory);
        }
    }
}
