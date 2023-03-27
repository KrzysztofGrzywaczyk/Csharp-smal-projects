using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_TicTacToe_Game
{
    public partial class MainWindow : Window
    {
        public bool isPlayer1turn { get; set; }
        public int moveCounter { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            NewGame();

        }

        public void NewGame()
        {
            moveCounter = 0;
            GetReadyButton(Button1);
            GetReadyButton(Button2);
            GetReadyButton(Button3);
            GetReadyButton(Button4);
            GetReadyButton(Button5);
            GetReadyButton(Button6);
            GetReadyButton(Button7);
            GetReadyButton(Button8);
            GetReadyButton(Button9);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            if (moveCounter > 8)
            {
                NewGame();
                return;
            }

            var button = sender as Button;
            if (button.Content.ToString() == string.Empty)
            {
                if (isPlayer1turn)
                    button.Content = "X";
                else
                    button.Content = "O";

                moveCounter++;
                isPlayer1turn = !isPlayer1turn;
            }
            checkWin();

        }

        private void GetReadyButton(Button button)
        {
            button.Content = string.Empty;
            button.Background = Brushes.White;
        }

        private bool CheckButtons(Button b1, Button b2, Button b3)
        {
            if (b1.Content.ToString() != string.Empty &&
                b1.Content == b2.Content &&
                b2.Content == b3.Content)
            {
                b1.Background = Brushes.Green;
                b2.Background = Brushes.Green;
                b3.Background = Brushes.Green;
                return true; ;
            }
            else return false;
        }

        private bool checkWin()
        {

            if (
            // rows
            CheckButtons(Button1, Button2, Button3) ||
            CheckButtons(Button4, Button5, Button6) ||
            CheckButtons(Button7, Button8, Button9) ||
            // columns
            CheckButtons(Button1, Button4, Button7) ||
            CheckButtons(Button2, Button5, Button8) ||
            CheckButtons(Button3, Button6, Button9) ||
            // diagonals
            CheckButtons(Button1, Button5, Button9) ||
            CheckButtons(Button3, Button5, Button7)
            )
            {
                moveCounter = 9;
                return true;
            }
            else return false;

        }
    }
}
