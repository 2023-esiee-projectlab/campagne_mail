using ESIEE_2_Campagne_Mail_v2;
using System.Diagnostics;

namespace ESIEE_2_Campagne_Mail
{
    public partial class CampaignNameView : Form
    {
        private string? message;
        private string? campaignName;

        /// <summary>
        /// Constructeur
        /// </summary>
        public CampaignNameView()
        {
            // Initialisation des composants de la vue
            InitializeComponent();
            // Nettoyage du label d'erreur
            clearWarning();
            // V�rification du nom de campagne
            checkNameCampagne();
        }

        /// <summary>
        /// V�rification de l'existance d'un nom de campagne
        /// </summary>
        private void checkNameCampagne()
        {
            if (!String.IsNullOrEmpty(MailCampView.Instance.Manager.GetCampagne().Nom))
                textBoxNewCampaignContent.Text = MailCampView.Instance.Manager.GetCampagne().Nom;
        }
        
        /// <summary>
        /// Bouton de v�rification � la bonne cr�ation d'une nouvelle campagne.
        /// </summary>
        private void buttonCreateCampagneClick(object sender, EventArgs e)
        {
            // Nettoyage du label d'erreur
            clearWarning();

            // R�cuparation du nom saisi dans le champ de texte
            campaignName = textBoxNewCampaignContent.Text;

            // V�rification de la saisie
            if (!string.IsNullOrEmpty(campaignName)
                && !String.IsNullOrEmpty(MailCampView.Instance.Manager.GetCampagne().Nom)
                && !campaignName.Equals(MailCampView.Instance.Manager.GetCampagne().Nom)
            )
            {
                //On enregistre le nom de la campagne
                MailCampView.Instance.Manager.GetCampagne().Nom = campaignName;
                // Pr�paration du message d'erreur
                message = "La campagne \"" + campaignName + "\" a bien �t� cr��.";
                // warning message
                labelWarning.Text = "[Campagne] " + message;
                labelWarning.ForeColor = System.Drawing.Color.Green;
                //-
                Debug.WriteLine("[Campagne] " + message + " - Nom : " + campaignName);
            }
            else
            {
                // Pr�paration du message d'erreur
                message = "La campagne n'a pas pu �tre cr�� car le nom n'est pas correcte ou celui-ci existe d�j�.";
                // warning message
                labelWarning.Text = "[Campagne] " + message;
                labelWarning.ForeColor = System.Drawing.Color.Red;
                //-
                Debug.WriteLine("[Campagne] " + message  + " - Nom : " + campaignName);
            }
        }

        /// <summary>
        /// Nettoyage de l'affichage du label d'erreur.
        /// </summary>
        private void clearWarning()
        {
            labelWarning.Text = "";
        }
    }
}