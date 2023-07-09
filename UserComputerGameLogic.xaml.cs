using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KrupaTikTacToe
{
    
    public partial class UserComputerGameLogic : Window
    {

        #region Private Members


        private DiskStyle[] result;
        private bool PlayerX;

        private bool End;

        #endregion

        #region Constructor

        public UserComputerGameLogic()
        {
            InitializeComponent();
            Game();
        }

        #endregion


        private void Game()
        {

            result = new DiskStyle[9];

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = DiskStyle.Free;
            }

            PlayerX=true;

            container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content=string.Empty;
                button.Background = Brushes.Cyan;
                button.Foreground = Brushes.RoyalBlue;

            });

            
            End = false;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (End)
            {
                Game();
                return;
            }

            var button = (Button)sender;

            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            var index = column +(row*3);
            if (result[index] != DiskStyle.Free)
            {
                return;
            }

            if (PlayerX)
                result[index]=DiskStyle.Cross;
            else
                result[index]=DiskStyle.Nought;

            button.Content = PlayerX ? "X" : "O";

            // Change Nought to Green
            if (PlayerX)
            {
                button.Foreground = Brushes.Brown;
            }

            if (PlayerX)
            {
                PlayerX = false;

            }
            else
            {
                PlayerX = true;
            }

            CheckForWinner();

        }

      

        private void CheckForWinner()
        {
            # region Horizontal Wins

            // Check For Horizontal 
            // Row 0
            if (result[0] != DiskStyle.Free && (result[0] & result[1] & result[2]) == result[0])
            {
                // Game ends
                End = true;

                // Highlight winning cells in green
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
            }



            // Row 1

            if (result[3] != DiskStyle.Free && (result[3] & result[4] & result[5]) == result[3])
            {
                // Game ends
                End = true;

                // Highlight winning cells in green
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
            }

            // Row 2
            if (result[6] != DiskStyle.Free && (result[6] & result[7] & result[8]) == result[6])
            {
                // Game ends
                End = true;

                // Highlight winning cells in green
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
            }

            #endregion

            # region Vertical Wins

            // Check for vertical wins
            //
            // column 0
            //
            if (result[0] != DiskStyle.Free && (result[0] & result[3] & result[6]) == result[0])
            {
                // Game ends
                End = true;

                // Highlight winning cells in green
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
            }

            // column 1
            if (result[1] != DiskStyle.Free && (result[1] & result[4] & result[7]) == result[1])
            {
                // Game ends
                End = true;

                // Highlight winning cells in green
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
            }

            // Col 3
            if (result[2] != DiskStyle.Free && (result[2] & result[5] & result[8]) == result[2])
            {
                // Game ends
                End = true;

                // Highlight winning cells in green
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
            }

            #endregion


            #region diagonal Wins

            // Check Diagonal win
            // Top Left Bottom Right
            if (result[0] != DiskStyle.Free && (result[0] & result[4] & result[8]) == result[0])
            {
                // Game ends
                End = true;

                // Highlight winning cells in green
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
            }

            // Top Right Bottom Left
            if (result[2] != DiskStyle.Free && (result[2] & result[4] & result[6]) == result[2])
            {
                // Game ends
                End = true;

                // Highlight winning cells in green
                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.Green;
            }

            # endregion

            if (!result.Any(result => result == DiskStyle.Free))
            {
                End = true;

                // Turn all cells orange
                container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Red;

                });

            }
        }
    }
}
