namespace GameElement
{
    //on crée un bateau
    public class bateau
    {
        //le bateau est definit par son nom , sa taille , s'il est touché ou coulé
        public int taille { get; set; }
        public type nom { get; set; }
        public bool coulé { get; set; }
        public int touché { get; set; }

        public bateau(type nom, int taille)
        {
            //on initialise les attributs 
            this.taille = taille;
            this.nom = nom;
            this.coulé = false;
            this.touché = 0;
        }

        public bool toucher()
        {
            //on crée une methode si le bateau est touché
            // si touché alors on ajoute "1" à touche 
            this.touché +=1;
            // si la valeur de touché vaut la taille du bateau alors on dit qu'il est coulé 
            if (this.touché == this.taille)
            {
                // on signale que le bateau est coulé
                this.coulé = true;
            }
            // on retourne la valeur de " coulé "
            return this.coulé;
        }
    }
}
