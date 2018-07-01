using CocosSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SkiaStudy
{
	public class HomePage : ContentPage
	{
        GameScene gameScene;
		public HomePage ()
		{
            var grid = new Grid();
            Content = grid;
            grid.RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
            };
            CreateTopHalf(grid);
            CreateBottomHalf(grid);
        }

        void CreateTopHalf(Grid grid)
        {
            var gameView = new CocosSharpView()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                ViewCreated = HandleViewCreated
            };
            grid.Children.Add(gameView, 0, 0);
        }

        void CreateBottomHalf(Grid grid)
        {
            var stackLayout = new StackLayout();
            var grid_arrow = new Grid();

            grid_arrow.RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
            };

            grid_arrow.ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
            };


            var moveLeftButton = new Button
            {
                Text = "Left"
            };
            moveLeftButton.Clicked += (sender, e) => gameScene.MoveCircleLeft();
            grid_arrow.Children.Add(moveLeftButton, 0, 1);

            var moveRightCircle = new Button
            {
                Text = "Right"
            };
            moveRightCircle.Clicked += (sender, e) => gameScene.MoveCircleRight();
            grid_arrow.Children.Add(moveRightCircle, 2, 1);


            var moveUpCircle = new Button
            {
                Text = "Up"
            };
            moveUpCircle.Clicked += (sender, e) => gameScene.MoveCircleUp();
            grid_arrow.Children.Add(moveUpCircle, 1, 0);

            var moveDownCircle = new Button
            {
                Text = "Down"
            };
            moveDownCircle.Clicked += (sender, e) => gameScene.MoveCircleDown();
            grid_arrow.Children.Add(moveDownCircle, 1, 1);





            grid.Children.Add(grid_arrow, 0, 1);
            
        }

        void HandleViewCreated(object sender, EventArgs e)
        {
            var gameView = sender as CCGameView;
            if(gameView != null)
            {
                gameView.DesignResolution = new CCSizeI(100, 100);
                gameScene = new GameScene(gameView);
                gameView.RunWithScene(gameScene);
            }
        }

        
	}
}