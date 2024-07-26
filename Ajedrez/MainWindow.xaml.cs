using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace Ajedrez {
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        const int gridSize = 30;
        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Program.MiFuncion();
            checker.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.LightBlue);
            CreateBoard();
            CreatePieces();
        }

        private void CreateBoard() {
            RowDefinition[] cellW = new RowDefinition[8];
            ColumnDefinition[] cellH = new ColumnDefinition[8];
            Grid[] gridArr = new Grid[64];
            int color = 0;
            int cycle = 1;
            int num = 0;

            for (int i = 1; i <= 64; i++) {
                Grid grid = new Grid {
                    Width = 600 / 8,
                    Height = 600 / 8,
                    Name = "cell" + i + 1.ToString(),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Background = ColorCell(color),
                };

                gridArr[i - 1] = grid;

                color++;
                if (i == 8 * cycle) {
                    color++;
                    cycle++;
                }
            }

            for (int j = 0; j < 8; j++) {
                for (int k = 0; k < 8; k++) {
                    
                    Grid.SetColumn(gridArr[num], j);
                    Grid.SetRow(gridArr[num], k);
                    checker.Children.Add(gridArr[num]);
                    num++;

                }
            } 
        }

        private void CreatePieces() {
            // Ruta de las imágenes
            string whitePawnPath = "C:/Users/ReyRo/OneDrive/Documents/Proyectos/C#/Ajedrez/Ajedrez/Assets/pawnWhite.png";
            string blackPawnPath = "C:/Users/ReyRo/OneDrive/Documents/Proyectos/C#/Ajedrez/Ajedrez/Assets/pawnBlack.png";

            // Crear peones blancos
            for (int i = 0; i < 8; i++) {
                BitmapImage bitmapWP = new BitmapImage(new Uri(whitePawnPath));

                System.Windows.Controls.Image imageWP = new System.Windows.Controls.Image {
                    Name = "Pawn",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Source = bitmapWP
                };

                Grid.SetColumn(imageWP, i);
                Grid.SetRow(imageWP, 1);
                checker.Children.Add(imageWP);
            }

            // Crear peones negros
            for (int i = 0; i < 8; i++) {
                BitmapImage bitmapBP = new BitmapImage(new Uri(blackPawnPath));

                System.Windows.Controls.Image imageBP = new System.Windows.Controls.Image {
                    Name = "Pawn",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Source = bitmapBP
                };

                Grid.SetColumn(imageBP, i);
                Grid.SetRow(imageBP, 6);
                checker.Children.Add(imageBP);
            }
        }

        private static SolidColorBrush ColorCell(int i) {
            SolidColorBrush color = new SolidColorBrush();
            if ((i + 1) % 2 == 1)
                 color = new System.Windows.Media.
                    SolidColorBrush(System.Windows.Media.Colors.Beige);
            else
                 color = new System.Windows.Media.
                    SolidColorBrush(System.Windows.Media.Colors.DarkGreen);
            return color;
        }
    }
}
