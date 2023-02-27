using ESIEE_2_Campagne_Mail_v2;
using System.Diagnostics;

namespace ESIEE_2_Campagne_Mail
{
    public partial class CreateCampaignView : Form
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public CreateCampaignView()
        {
            // Initialisation des composants de la vue
            InitializeComponent();
            // Nettoyage du label d'erreur
            clearWarning();
        }
        
        /// <summary>
        /// Bouton de v�rification � la bonne cr�ation d'une nouvelle campagne.
        /// </summary>
        private void buttonCreateCampagneClick(object sender, EventArgs e)
        {
            // Nettoyage du label d'erreur
            clearWarning();

            // R�cuparation du nom saisi dans le champ de texte
            string campaignName = textBoxNewCampaignContent.Text;

            // V�rification de la saisie
            if (!string.IsNullOrEmpty(campaignName)
                && !String.IsNullOrEmpty(MailCampView.Instance.Manager.GetCampagne().Nom)
                && !campaignName.Equals(MailCampView.Instance.Manager.GetCampagne().Nom)
            )
            {
                //On enregistre le nom de la campagne
                MailCampView.Instance.Manager.GetCampagne().Nom = campaignName;
                //-
                Debug.WriteLine("[Campagne] La campagne a �t� cr��. - Nom : " + campaignName);
            }
            else
            {
                // Pr�paration du message d'erreur
                string message = "La campagne n'a pas pu �tre cr�� car le nom n'est pas correcte ou celui-ci existe d�j�.";
                // warning message
                labelWarning.Text = "[Campagne] " + message;
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