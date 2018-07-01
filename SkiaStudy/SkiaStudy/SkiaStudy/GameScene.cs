using CocosSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkiaStudy
{
    class GameScene : CCScene
    {
        CCDrawNode circle;
        public GameScene(CCGameView gameView) : base(gameView)
        {
            var layer = new CCLayer();
            AddLayer(layer);
            circle = new CCDrawNode();
            layer.AddChild(circle);
            circle.DrawCircle(new CCPoint(0, 0), radius: 15, color: CCColor4B.White);
            circle.PositionX = 50;
            circle.PositionY = 50;
        }

        public void MoveCircleLeft()
        {
            circle.PositionX -= 10;
        }

        public void MoveCircleRight()
        {
            circle.PositionX += 10;
        }

        public void MoveCircleUp()
        {
            circle.PositionY += 10;
        }

        public void MoveCircleDown()
        {
            circle.PositionY -= 10;
        }
    }
}
