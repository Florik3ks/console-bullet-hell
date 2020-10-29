using System;

namespace console_bullet_hell
{
    class Bullet
    {
        public float x;
        public float y;
        public float direction;
        private float speed;
        public Bullet(int x, int y)
        {
            this.x = x;
            this.y = y;
            // Geschwindigkeit
            float speed = new Random().Next(1, 7);
            speed /= 25;
            this.speed = speed;
            // Richtung zum Spieler
            float xDiff = Player.getX() - x;
            float yDiff = Player.getY() - y;
            this.direction = MathF.Atan2(yDiff, xDiff) * 180.0f / MathF.PI;

        }
        public void Move()
        {
            float dir = (MathF.PI / 180) * this.direction;
            this.x += (this.speed * MathF.Cos(dir));
            this.y += (this.speed * MathF.Sin(dir));
            // flew out of bounds
            if (this.x > Program.gridWidth - 2 || this.x < 2)
            {
                Program.bullets.Remove(this);
                Program.dodgedBullets++;
            }
            if (this.y > Program.gridHeight - 2 || this.y < 2)
            {
                Program.bullets.Remove(this);
                Program.dodgedBullets++;
            }
            // hit Player
            if (this.x <= Player.getX() + 2 && this.x >= Player.getX() - 2 && this.y <= Player.getY() + 1 && this.y >= Player.getY() - 1)
            {
                Program.running = false;
            }
        }
    }
}