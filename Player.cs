namespace console_bullet_hell
{
    public static class Player
    {
        public static char[,] sprite = new char[,]{
            {'╔','═','╦','═','╗'},
            {'╠','═','╬','═','╣'},
            {'╚','═','╩','═','╝'}};
        private static int x;
        private static int y;
        public static void setPosition(int x, int y)
        {
            Player.x = x;
            Player.y = y;
        }
        public static int getX()
        {
            return Player.x;
        }
        public static int getY()
        {
            return Player.y;
        }
        public static void Move(int relativeX, int relativeY)
        {
            Player.x += relativeX;
            Player.y += relativeY;
        }
    }
}