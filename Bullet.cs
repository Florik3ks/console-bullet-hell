using System;

namespace console_bullet_hell
{
    class Bullet
    {
        public int x;
        public int y;
        public float direction;
        private float speed;
        public Bullet(int x, int y)
        {
            this.x = x;
            this.y = y;
            // Geschwindigkeit
            float speed = 1.5f;//new Random().Next(1, 7);
            // speed /= 10;
            this.speed = speed;
            // Richtung zum Spieler
            float xDiff = Player.getX() - x;
            float yDiff = Player.getY() - y;
            this.direction = MathF.Atan2(yDiff, xDiff) * 180.0f / MathF.PI;

        }
        public void Move(){
            float dir = (MathF.PI / 180) * this.direction;
            this.x += (int)(this.speed * MathF.Cos(dir));
            this.y += (int)(this.speed * MathF.Sin(dir));
            Console.Write("\r" + direction);
            if(this.x > Program.gridWidth - 2){
                Program.bullets.Remove(this);
            }
            else if(this.x < 2){
                Program.bullets.Remove(this);
            }
            if (this.y < 2){
                Program.bullets.Remove(this);
            }
            else if(this.y > Program.gridHeight - 2){
                Program.bullets.Remove(this);
            }
        }
    }
}