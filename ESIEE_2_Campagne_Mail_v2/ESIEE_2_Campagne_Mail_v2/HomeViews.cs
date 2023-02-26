namespace ESIEE_2_Campagne_Mail_v2
{
    public partial class HomeViews : Form
    {
        public HomeViews()
        {
            // Chargement des composants
            InitializeComponent();
            
            // Chargement de la configuration de d�marrage
            startConfiguration();
        }

        /// <summary>
        /// Configuration de d�marrage du formulaire
        /// </summary>
        private void startConfiguration()
        {
            // D�finissez le style de bordure du formulaire � une bo�te de dialogue.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            // Maximizer la bo�te de maximisation.
            this.MaximizeBox = false;
            // Supprimer la bo�te de r�duction.
            this.MinimizeBox = false;
            // D�finir la position de d�part du formulaire au centre de l'�cran.
            this.StartPosition = FormStartPosition.CenterScreen;
            // Affichez le formulaire sous la forme d'une bo�te de dialogue modale.
            //this.ShowDialog();
        }
    }
}