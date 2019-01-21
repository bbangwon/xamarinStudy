using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Animation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class XamagonXuzzlePage : ContentPage
    {
        static readonly int NUM = 4;

        XamagonXuzzleTile[,] tiles = new XamagonXuzzleTile[NUM, NUM];
        int emptyRow = NUM - 1;
        int emptyCol = NUM - 1;

        double tileSize;
        bool isBusy;

        public XamagonXuzzlePage()
        {
            InitializeComponent();

            for (int row = 0; row < NUM; row++)
            {
                for (int col = 0; col < NUM; col++)
                {
                    if (row == NUM - 1 && col == NUM - 1)
                        break;

                    ImageSource imageSource =
                        ImageSource.FromResource("Animation.Images.Bitmap" + row + col + ".png");

                    XamagonXuzzleTile tile = new XamagonXuzzleTile(row, col, imageSource);

                    TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer
                    {
                        Command = new Command(OnTileTapped),
                        CommandParameter = tile
                    };

                    tile.GestureRecognizers.Add(tapGestureRecognizer);

                    tiles[row, col] = tile;
                    absoluteLayout.Children.Add(tile);
                }
            }
        }

        async private void OnTileTapped(object parameter)
        {
            if (isBusy)
                return;

            isBusy = true;
            XamagonXuzzleTile tappedTile = (XamagonXuzzleTile)parameter;
            await ShiftIntoEmpty(tappedTile.Row, tappedTile.Col);
            isBusy = false;
        }

        async private Task ShiftIntoEmpty(int tappedRow, int tappedCol, uint length = 100)
        {
            if(tappedRow == emptyRow && tappedCol != emptyCol)
            {
                int inc = Math.Sign(tappedCol - emptyCol);
                int begCol = emptyCol + inc;
                int endCol = tappedCol + inc;

                for (int col = begCol; col != endCol; col+=inc)
                {
                    await AnimateTile(emptyRow, col, emptyRow, emptyCol, length);
                }
            }
            else if(tappedCol == emptyCol && tappedRow != emptyRow)
            {
                int inc = Math.Sign(tappedRow - emptyRow);
                int begRow = emptyRow + inc;
                int endRow = tappedRow + inc;

                for(int row = begRow; row != endRow; row += inc)
                {
                    await AnimateTile(row, emptyCol, emptyRow, emptyCol, length);
                }
            }
        }

        async private Task AnimateTile(int row, int col, int newRow, int newCol, uint length)
        {
            XamagonXuzzleTile animaTile = tiles[row, col];
            Rectangle rect = new Rectangle(emptyCol * tileSize, emptyRow * tileSize, tileSize, tileSize);

            await animaTile.LayoutTo(rect, length);

            AbsoluteLayout.SetLayoutBounds(animaTile, rect);

            tiles[newRow, newCol] = animaTile;
            animaTile.Row = newRow;
            animaTile.Col = newCol;
            tiles[row, col] = null;
            emptyRow = row;
            emptyCol = col;
        }

        private void OnContentViewSizeChanged(object sender, EventArgs e)
        {
            ContentView contentView = (ContentView)sender;
            double width = contentView.Width;
            double height = contentView.Height;

            if (width <= 0 || height <= 0)
                return;

            stackLayout.Orientation = (width < height) ? StackOrientation.Vertical : StackOrientation.Horizontal;

            tileSize = Math.Min(width, height) / NUM;
            absoluteLayout.WidthRequest = NUM * tileSize;
            absoluteLayout.HeightRequest = NUM * tileSize;

            foreach (View view in absoluteLayout.Children)
            {
                XamagonXuzzleTile tile = (XamagonXuzzleTile)view;

                AbsoluteLayout.SetLayoutBounds(tile, new Rectangle(tile.Col * tileSize, tile.Row * tileSize, tileSize, tileSize));
            }
        }

        async private void OnRandomizeButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.IsEnabled = false;
            Random rand = new Random();
            isBusy = true;

            for (int i = 0; i < 100; i++)
            {
                await ShiftIntoEmpty(rand.Next(NUM), emptyCol, 25);
                await ShiftIntoEmpty(emptyRow, rand.Next(NUM), 25);
            }
            button.IsEnabled = true;
            isBusy = false;
        }
    }
}