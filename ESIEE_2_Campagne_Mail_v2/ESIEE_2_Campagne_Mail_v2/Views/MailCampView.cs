using ESIEE_2_Campagne_Mail;
using ESIEE_2_Campagne_Mail.gui;
using ESIEE_2_Campagne_Mail.process;
using ESIEE_2_Campagne_Mail_v2.Views;
using FontAwesome.Sharp;
using System.Diagnostics;
using static ESIEE_2_Campagne_Mail_v2.utils.UtilsDesign;

namespace ESIEE_2_Campagne_Mail_v2
{
    public partial class MailCampView : Form
    {
        // - - - [Instances] - - -
        public static MailCampView? Instance;
        internal CampagneManager Manager { get; }

        // - - - [Variables] - - -
        private String? campagneName;
        private IconButton? currentBtn;
        private Panel? leftBorderBtn;
        private Form? currentChildForm;

        /// <summary>
        /// Constructeur
        /// </summary>
        public MailCampView()
        {
            // Chargement des composants
            InitializeComponent();
            // Chargement de la configuration de d�marrage
            startConfiguration(true, true, true, "center", false);
            // Surcharge du formulaire
            initForm();
        }

        // - - - [Methods] - - -

        /// <summary>
        /// Configuration de d�marrage du formulaire.
        /// </summary>
        private void startConfiguration(bool fixe, bool maximize, bool reduce, string position, bool show)
        {
            // D�finit le style de bordure du formulaire � une bo�te de dialogue.
            if (fixe)
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
            // Maximise la bo�te de maximisation.
            if (maximize)
                this.MaximizeBox = true;
            // Supprime la bo�te de r�duction.
            if (reduce)
                this.MinimizeBox = true;
            // D�finit la position de d�part du formulaire au centre de l'�cran.
            if (position == "center")
                this.StartPosition = FormStartPosition.CenterScreen;
            // Affiche le formulaire sous la forme d'une bo�te de dialogue modale.
            if (show)
                this.ShowDialog();
        }

        /// <summary>
        /// Surcharge du formulaire
        /// </summary>
        private void initForm()
        {
            //Form
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        /// <summary>
        /// Ouverture d'un nouveau formulaire dans notre formulaire principal.
        /// </summary>
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.Controls.Add(childForm);
            this.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            labelTopCurrentForm.Text = childForm.Text;
        }

        /// <summary>
        /// Activer un bouton si il a �t� cliqu�.
        /// </summary>
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();

                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = RGBColors.color3;
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                //Current Child Form Icon
                iconPictureBoxTopCurrentForm.IconChar = currentBtn.IconChar;
                //iconPictureBoxTopCurrentForm.IconColor = color;
            }
        }

        /// <summary>
        /// D�sactiver un bouton activer.
        /// </summary>
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = RGBColors.color5;
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        /// <summary>
        /// R�initialisation du formulaire principal.
        /// - D�sactiver un bouton activer.
        /// - Nettoyage de vue centrale du formulaire principal.
        /// </summary>
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconPictureBoxTopCurrentForm.IconChar = IconChar.Home;
            //iconPictureBoxTopCurrentForm.IconColor = Color.MediumPurple;
            labelTopCurrentForm.Text = "Accueil";
        }

        // - - - [Events] - - -

        /// <summary>
        /// Ouverture de l'accueil dans la vue centrale du formulaire principal.
        /// </summary>
        private void openHome()
        {
            Debug.WriteLine("[Open - Button - Home]");
            //-
            if (campagneName != null)
            {
                OpenChildForm(new Home(campagneName));
            }
            else
            {
                OpenChildForm(new Home(null));
            }
        }

        /// <summary>
        /// Nettoyage de la vue centrale du formulaire principal.
        /// </summary>
        private void clear()
        {
            Debug.WriteLine("[Clear - MailCamp View]");
            //6
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            Reset();
        }
        
        // - - - [Click Buttons] - - -

        /// <summary>
        /// Clique sur le bouton d'accueil
        /// et nettoie la vue centrale du formulaire principal.
        /// </summary>
        private void iconButtonHome_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[Click - Button - Home]");
            //-
            clear();
            //-
            ActivateButton(sender, RGBColors.color1);
            openHome();
        }

        /// <summary>
        /// Clique sur le bouton de nouvelle campagne
        /// et ouvre le formulaire de cr�ation de campagne.
        /// </summary>
        private void iconButtonCampaign_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[Click - Button - New Campaign]");
            //-
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new CreateCampaignView());
        }

        /// <summary>
        /// Clique sur le bouton de liste des mails
        /// et ouvre le formulaire de liste des mails.
        /// </summary>
        private void iconButtonMailsList_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[Click - Button - Mails List]");
            //-
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new ListeEmails());
        }

        /// <summary>
        /// Clique sur le bouton de message de la campagne
        /// et ouvre le formulaire d'�dition du message de la campagne.
        /// </summary>
        private void iconButtonCampaignMessage_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[Click - Button - Campaign Message]");
            //-
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new EditionMessage());
        }

        /// <summary>
        /// Clique sur le bouton de configuration du serveur SMTP
        /// et ouvre le formulaire de configuration du serveur SMTP.
        /// </summary>
        private void iconButtonConfigSMTP_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[Click - Button - Config SMTP]");
            //-
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new ConfigServerSMTP());
        }

        /// <summary>
        /// Clique sur le bouton de l'envoi de la campagne
        /// et ouvre le formulaire de l'envoi de la campagne.
        /// </summary>
        private void iconButtonCampaignSend_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[Click - Button - Campaign Send]");
            //-
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new EnvoiCampagne());
        }

        /// <summary>
        /// Clique sur le bouton de � propos
        /// et ouvre le formulaire d'informations � propos de l'application.
        /// </summary>
        private void iconButtonAboutApp_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[Click - Button - About Appd]");
            //-
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new AboutView());
        }

        /// <summary>
        /// Clique sur le bouton de fermeture de l'application.
        /// </summary>
        private void iconButtonExitApp_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[Click - Button - Exit App]");
            //-
            Application.Exit();
        }
    }
}