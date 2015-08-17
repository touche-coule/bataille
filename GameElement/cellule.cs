namespace GameElement
{
    public class cellule
    {
        public int horizontal { get; set; }
        public int vertical { get; set; }
        public bool used { get; set; }
        public bateau bateau { get; set; }
        public bool assignement { get; set; }

        public cellule(int horizontal, int vertical)
        {
            this.horizontal = horizontal;
            this.vertical = vertical;
            this.used = false;
            this.assignement = false;
        }

        public void ajoutBateau(bateau bateau)
        {
            this.bateau = bateau;
            this.assignement = true;
        }

        public int attaque()
        {
            if (this.used == false)
            {
                if (this.assignement)
                {
                    if (this.bateau.toucher())
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                return 4;
            }
        }
    }
}
