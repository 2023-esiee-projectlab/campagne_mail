namespace ESIEE_2_Campagne_Mail_v2
{
    public partial class MailCamp : Form
    {
        List<Panel> listPanel = new List<Panel>();

        /// <summary>
        /// Constructeur
        /// </summary>
        public MailCamp()
        {
            // Chargement des composants
            InitializeComponent();
            // Chargement de la configuration de d�marrage
            startConfiguration();
            // Chargement des panels
            loadPanels();
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

        /// <summary>
        /// Configuration des panels
        /// </summary>
        private void loadPanels() {
            // Masquage des panels
            panelHome.Hide();
            
            // Taille compl�te du panel
            panelHome.Dock = DockStyle.Fill;
            // Centralisation du panel
            panelHome.Location = new Point(0, 0);
            // Fond transparent du panel � 10
            panelHome.BackColor = Color.FromArgb(10, 0, 0, 0);

            // Ajout des panels dans la liste
            listPanel.Add(panelHome);

            // Afficher le panel de d�marrage
            panelHome.Show();
        }

        private void buttonNomDeLaCampagneClick(object sender, EventArgs e){}
    }
}