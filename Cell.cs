namespace console_bullet_hell
{
    public class Cell
    {
        public string val;
        public bool occupied;

        public void Clear()
        {
            if (val == "*")
            {
                return;
            }
            if (occupied)
            {
                occupied = false;
                return;
            }
            val = " ";
        }

        public void Set(string _val)
        {
            if (val == "*")
            {
                return;
            }
            occupied = true;
            val = _val;
        }
    }

}