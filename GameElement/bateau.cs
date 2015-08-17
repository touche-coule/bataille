namespace GameElement
{
    public class bateau
    {
        public int taille { get; set; }
        public type nom { get; set; }
        public bool coulé { get; set; }
        public int touché { get; set; }

        public bateau(type nom, int taille)
        {
            this.taille = taille;
            this.nom = nom;
            this.coulé = false;
            this.touché = 0;
        }

        public bool toucher()
        {
            this.touché +=1;
            if (this.touché == this.taille)
            {
                this.coulé = true;
            }
            return this.coulé;
        }
    }
}
