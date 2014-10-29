using sharpPDF;
using sharpPDF.Enumerators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using HelpParebrise.Model;
using HelpParebrise.ViewModel;

namespace HelpParebrise.Common
{
    public class Printing
    {
        public static void printIntervention(Intervention inter)
        {
            CustomerVM.Instance.getCustomers();
            ContactsVM.Instance.getContacts();
            VehiculeVM.Instance.getVehicules();
            InsuranceVM.Instance.getInsurances();
            PieceVM.Instance.getPieces();
            PieceInterventionVM.Instance.getPiecesIntervention();
            TvaVM.Instance.getTva();
            ModePaiementVM.Instance.getModesPaiement();
            TypePrestationVM.Instance.getTypePrestations();

            Client client = CustomerVM.Instance.Customers.Where(x => x.indice_client == inter.indice_client).FirstOrDefault();
            Contact contact_client = ContactVM.Instance.Contacts.Where(x => x.indice_contact == client.indice_contact).FirstOrDefault();
            Vehicule vehicule = VehiculeVM.Instance.Vehicules.Where(x => x.indice_vehicule == inter.indice_vehicule).FirstOrDefault();
            Assurance assurance_client = InsuranceVM.Instance.Insurances.Where(x => x.indice_assurance == client.indice_assurance).FirstOrDefault();
            List<PieceIntervention> pieces_intervention = PieceInterventionVM.Instance.PiecesIntervention.Where(x => x.indice_intervention == inter.indice_intervention).ToList();
            Tva tva_intervention = TvaVM.Instance.TVA.Where(x => x.id_tva == inter.id_tva).FirstOrDefault();
            ModePaiement mode_paiement = ModePaiementVM.Instance.ModesPaiement.Where(x => x.indice_mode_paiement == inter.indice_mode_paiement).FirstOrDefault();
            Prestation type_prestation = TypePrestationVM.Instance.TypePrestations.Where(x => x.indice_prestation == inter.indice_prestation).FirstOrDefault();

            pdfDocument myDoc = new pdfDocument("TUTORIAL", "ME");
            int numberLine = 521;

            pdfPage myFirstPage = myDoc.addPage();

            string CST_PATH_LOGOS = @"\logos\";
            string fullPathLogos = AppDomain.CurrentDomain.BaseDirectory + CST_PATH_LOGOS;
            FileInfo fi = new FileInfo(fullPathLogos + "help_parebrise.png");
            //FileInfo IconEuros = new FileInfo(fullPathLogos + "euro.png");
            //FileInfo IconEurosBold = new FileInfo(fullPathLogos + "euroBold.png");
            if (fi.Exists)
            {
                myFirstPage.addImage(fi.FullName, 70, 670);
            }

            myFirstPage.addText("HELP PARE BRISE SAS", 300, 750, predefinedFont.csTimesBold, 12);
            myFirstPage.addText("10 RUE EUGENE HENAFF ", 300, 735, predefinedFont.csTimesBold, 10);
            myFirstPage.addText("ZA DU BUISSON DE LA COULDRE", 300, 720, predefinedFont.csTimesBold, 10);

            myFirstPage.addText("78190 TRAPPES", 300, 705, predefinedFont.csTimesBold, 10);
            myFirstPage.addText("TEL : 06 64 35 38 96", 300, 690, predefinedFont.csTimesBold, 10, new pdfColor(0, 0, 255));
            myFirstPage.addText("801 994 435 000 15", 300, 675, predefinedFont.csTimesBold, 10);

            #region TOP LEFT
            myFirstPage.drawRectangle(20, 660, 250, 647, new pdfColor(predefinedColor.csBlack), new pdfColor(218, 150, 148), 1, predefinedLineStyle.csNormal);
            myFirstPage.addText("CLIENT", 30, 650, predefinedFont.csTimesBold, 10);

            myFirstPage.drawRectangle(20, 646, 250, 560, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 1, predefinedLineStyle.csNormal);

            myFirstPage.addText("Client :", 25, 635, predefinedFont.csTimes, 9);
            myFirstPage.addText(client.nom, 130, 635, predefinedFont.csTimes, 9);

            myFirstPage.addText("Contact :", 25, 623, predefinedFont.csTimes, 9);
            myFirstPage.addText(string.Format("{0} {1}", contact_client.prenom, contact_client.nom), 130, 623, predefinedFont.csTimes, 9);

            myFirstPage.addText("Adresse :", 25, 611, predefinedFont.csTimes, 9);
            myFirstPage.addText(client.adresse_siege, 130, 611, predefinedFont.csTimes, 9);

            myFirstPage.addText("CP / ville :", 25, 599, predefinedFont.csTimes, 9);
            myFirstPage.addText(string.Format("{0} {1}", client.code_postal, client.ville), 130, 599, predefinedFont.csTimes, 9);

            myFirstPage.addText("Tél :", 25, 587, predefinedFont.csTimes, 9);
            myFirstPage.addText(client.numero_telephone_1, 130, 587, predefinedFont.csTimes, 9);

            myFirstPage.addText("Fax :", 25, 575, predefinedFont.csTimes, 9);
            myFirstPage.addText(client.numero_fax, 130, 575, predefinedFont.csTimes, 9);

            myFirstPage.addText("Email :", 25, 563, predefinedFont.csTimes, 9);
            myFirstPage.addText(client.adresse_email, 130, 563, predefinedFont.csTimes, 9);

            myFirstPage.drawRectangle(20, 560, 250, 547, new pdfColor(predefinedColor.csBlack), new pdfColor(218, 150, 148), 1, predefinedLineStyle.csNormal);
            myFirstPage.addText("ADRESSE D'INTERVENTION", 30, 550, predefinedFont.csTimesBold, 10);

            myFirstPage.drawRectangle(20, 547, 250, 473, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 1, predefinedLineStyle.csNormal);
            myFirstPage.addText("Adresse :", 25, 536, predefinedFont.csTimes, 9);
            myFirstPage.addText("CP / ville :", 25, 524, predefinedFont.csTimes, 9);
            myFirstPage.addText("Contact :", 25, 512, predefinedFont.csTimes, 9);
            myFirstPage.addText("CP / ville :", 25, 500, predefinedFont.csTimes, 9);
            myFirstPage.addText("Tél :", 25, 488, predefinedFont.csTimes, 9);
            myFirstPage.addText("Email :", 25, 476, predefinedFont.csTimes, 9);

            myFirstPage.drawRectangle(20, 473, 90, 460, new pdfColor(predefinedColor.csBlack), new pdfColor(218, 150, 148), 1, predefinedLineStyle.csNormal);
            myFirstPage.addText("DATE", 30, 463, predefinedFont.csTimesBold, 10);

            myFirstPage.drawRectangle(90, 473, 250, 460, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 1, predefinedLineStyle.csNormal);
            myFirstPage.addText("Date a inserer", 95, 463, predefinedFont.csTimesBold, 10);
            #endregion

            #region TOP RIGHT
            myFirstPage.drawRectangle(250, 660, 580, 647, new pdfColor(predefinedColor.csBlack), new pdfColor(218, 150, 148), 1, predefinedLineStyle.csNormal);
            myFirstPage.addText("IDENTIFICATION DU VEHICULE", 260, 650, predefinedFont.csTimesBold, 10);

            myFirstPage.drawRectangle(250, 646, 580, 560, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 1, predefinedLineStyle.csNormal);

            myFirstPage.addText("Marque :", 255, 635, predefinedFont.csTimes, 9);
            myFirstPage.addText(vehicule.marque, 430, 635, predefinedFont.csTimes, 9);

            myFirstPage.addText("Modèle :", 255, 623, predefinedFont.csTimes, 9);
            myFirstPage.addText(vehicule.modele, 430, 623, predefinedFont.csTimes, 9);

            myFirstPage.addText("Date de mise en service :", 255, 611, predefinedFont.csTimes, 9);
            myFirstPage.addText(vehicule.date_mise_en_service, 430, 611, predefinedFont.csTimes, 9);

            myFirstPage.addText("Immatriculation :", 255, 599, predefinedFont.csTimes, 9);
            myFirstPage.addText(vehicule.immatriculation, 430, 599, predefinedFont.csTimes, 9);

            myFirstPage.addText("Numéro de série :", 255, 587, predefinedFont.csTimes, 9);
            myFirstPage.addText(vehicule.numero_serie, 430, 587, predefinedFont.csTimes, 9);

            myFirstPage.addText("Type de véhicule :", 255, 575, predefinedFont.csTimes, 9);
            myFirstPage.addText(vehicule.type_vehicule, 430, 575, predefinedFont.csTimes, 9);

            myFirstPage.addText("Kilométrage :", 255, 563, predefinedFont.csTimes, 9);
            myFirstPage.addText(vehicule.kilometrage.ToString(), 430, 563, predefinedFont.csTimes, 9);

            myFirstPage.drawRectangle(250, 560, 580, 547, new pdfColor(predefinedColor.csBlack), new pdfColor(218, 150, 148), 1, predefinedLineStyle.csNormal);
            myFirstPage.addText("ELEMENTS DE FACTURATION", 260, 550, predefinedFont.csTimesBold, 10);

            myFirstPage.drawRectangle(250, 547, 580, 473, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 1, predefinedLineStyle.csNormal);
            myFirstPage.addText("N° de bon de commande :", 255, 536, predefinedFont.csTimes, 9);

            myFirstPage.addText(string.Format("Date d'intervention : {0}", inter.date_intervention), 440, 536, predefinedFont.csTimes, 9);
            myFirstPage.addText("Assurance :", 255, 524, predefinedFont.csTimes, 9);

            if(assurance_client != null)
                myFirstPage.addText(assurance_client.nom, 430, 524, predefinedFont.csTimes, 9);

            myFirstPage.addText("Adresse :", 255, 512, predefinedFont.csTimes, 9);

            if (assurance_client != null)
                myFirstPage.addText(assurance_client.adresse, 430, 512, predefinedFont.csTimes, 9);

            myFirstPage.addText("N° de contrat d'assurance :", 255, 500, predefinedFont.csTimes, 9);

            if (assurance_client != null)
                myFirstPage.addText(assurance_client.numero_contrat, 430, 500, predefinedFont.csTimes, 9);

            myFirstPage.addText("Tél :", 255, 488, predefinedFont.csTimes, 9);

            if (assurance_client != null)
                myFirstPage.addText(assurance_client.numero_telephone, 430, 488, predefinedFont.csTimes, 9);

            myFirstPage.addText("Date du sinistre :", 255, 476, predefinedFont.csTimes, 9);
            myFirstPage.addText(inter.date_sinistre, 430, 476, predefinedFont.csTimes, 9);

            myFirstPage.drawRectangle(250, 473, 370, 460, new pdfColor(predefinedColor.csBlack), new pdfColor(218, 150, 148), 1, predefinedLineStyle.csNormal);
            myFirstPage.addText("TYPE DE PRESTATION", 255, 463, predefinedFont.csTimesBold, 10);


            myFirstPage.drawRectangle(370, 473, 580, 460, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 1, predefinedLineStyle.csNormal);
            myFirstPage.addText(type_prestation.designation, 375, 463, predefinedFont.csTimesBold, 10);

            #endregion

            #region DETAILS FACTURE

            myFirstPage.drawRectangle(20, 460, 581, 434, new pdfColor(predefinedColor.csBlack), new pdfColor(218, 150, 148), 1, predefinedLineStyle.csNormal);
            myFirstPage.addText(string.Format("FACTURE N°{0}", inter.numero_facture), 260, 445, predefinedFont.csTimesBold, 12);

            myFirstPage.drawRectangle(20, 434, 80, 408, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(80, 434, 350, 408, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(350, 434, 420, 408, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(420, 434, 480, 408, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(480, 434, 530, 408, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(530, 434, 581, 408, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);

            myFirstPage.addText("Référence", 28, 418, predefinedFont.csTimesBold, 10);
            myFirstPage.addText("Description", 190, 418, predefinedFont.csTimesBold, 10);
            myFirstPage.addText("Quantité", 365, 418, predefinedFont.csTimesBold, 10);
            myFirstPage.addText("P.U HT", 435, 418, predefinedFont.csTimesBold, 10);
            myFirstPage.addText("Remise", 490, 418, predefinedFont.csTimesBold, 10);
            myFirstPage.addText("H.T €", 545, 418, predefinedFont.csTimesBold, 10);

            myFirstPage.drawRectangle(20, 408, 581, 393, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(20, 408, 80, 393, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(80, 408, 350, 393, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(350, 408, 420, 393, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(420, 408, 480, 393, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(480, 408, 530, 393, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(530, 408, 581, 393, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);

            myFirstPage.drawRectangle(20, 393, 581, 378, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(20, 393, 80, 378, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(80, 393, 350, 378, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(350, 393, 420, 378, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(420, 393, 480, 378, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(480, 393, 530, 378, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(530, 393, 581, 378, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);

            myFirstPage.drawRectangle(20, 378, 581, 363, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(20, 378, 80, 363, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(80, 378, 350, 363, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(350, 378, 420, 363, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(420, 378, 480, 363, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(480, 378, 530, 363, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(530, 378, 581, 363, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);

            myFirstPage.drawRectangle(20, 363, 581, 348, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(20, 363, 80, 348, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(80, 363, 350, 348, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(350, 363, 420, 348, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(420, 363, 480, 348, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(480, 363, 530, 348, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(530, 363, 581, 348, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);

            myFirstPage.drawRectangle(20, 348, 581, 333, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(20, 348, 80, 333, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(80, 348, 350, 333, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(350, 348, 420, 333, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(420, 348, 480, 333, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(480, 348, 530, 333, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(530, 348, 581, 333, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);

            myFirstPage.drawRectangle(20, 333, 581, 318, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(20, 333, 80, 318, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(80, 333, 350, 318, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(350, 333, 420, 318, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(420, 333, 480, 318, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(480, 333, 530, 318, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(530, 333, 581, 318, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);

            myFirstPage.drawRectangle(20, 318, 581, 303, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(20, 318, 80, 303, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(80, 318, 350, 303, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(350, 318, 420, 303, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(420, 318, 480, 303, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(480, 318, 530, 303, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(530, 318, 581, 303, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);

            myFirstPage.drawRectangle(20, 303, 581, 288, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(20, 303, 80, 288, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(80, 303, 350, 288, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(350, 303, 420, 288, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(420, 303, 480, 288, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(480, 303, 530, 288, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(530, 303, 581, 288, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);

            myFirstPage.drawRectangle(20, 288, 581, 273, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(20, 288, 80, 273, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(80, 288, 350, 273, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(350, 288, 420, 273, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(420, 288, 480, 273, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(480, 288, 530, 273, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(530, 288, 581, 273, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);

            myFirstPage.drawRectangle(20, 273, 581, 258, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(20, 273, 80, 258, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(80, 273, 350, 258, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(350, 273, 420, 258, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(420, 273, 480, 258, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(480, 273, 530, 258, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(530, 273, 581, 258, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);

            myFirstPage.drawRectangle(20, 258, 581, 243, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(20, 258, 80, 243, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(80, 258, 350, 243, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(350, 258, 420, 243, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(420, 258, 480, 243, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(480, 258, 530, 243, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(530, 258, 581, 243, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);

            myFirstPage.drawRectangle(20, 243, 581, 228, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(20, 243, 80, 228, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(80, 243, 350, 228, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(350, 243, 420, 228, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(420, 243, 480, 228, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(480, 243, 530, 228, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(530, 243, 581, 228, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);

            myFirstPage.drawRectangle(20, 228, 581, 213, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(20, 228, 80, 213, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(80, 228, 350, 213, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(350, 228, 420, 213, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(420, 228, 480, 213, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(480, 228, 530, 213, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(530, 228, 581, 213, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);

            myFirstPage.drawRectangle(20, 213, 581, 198, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(20, 213, 80, 198, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(80, 213, 350, 198, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(350, 213, 420, 198, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(420, 213, 480, 198, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(480, 213, 530, 198, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(530, 213, 581, 198, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 0, predefinedLineStyle.csNormal);
            #endregion

            #region PIECES INTERVENTION

            int lineStartY = 408;
            int lineEndY = 393;
            double valeurHT = 0.0;
            for (int i = 0; i < pieces_intervention.Count; i++)
            {
                myFirstPage.addText(pieces_intervention[i].reference, 30, (lineStartY - 11), predefinedFont.csTimes, 9);
                myFirstPage.addText(pieces_intervention[i].designation, 90, (lineStartY - 11), predefinedFont.csTimes, 9);
                myFirstPage.addText(pieces_intervention[i].quantite.ToString(), 380, (lineStartY - 11), predefinedFont.csTimes, 9);
                myFirstPage.addText(string.Format("{0}", pieces_intervention[i].prix.ToString()), 440, (lineStartY - 11), predefinedFont.csTimes, 9);
                //myFirstPage.addImage(IconEuros.FullName, 455, (lineStartY - 11));
                myFirstPage.addText(string.Format("{0} %", pieces_intervention[i].remise.ToString()), 495, (lineStartY - 11), predefinedFont.csTimes, 9);

                double valueWithoutRemise = pieces_intervention[i].quantite * pieces_intervention[i].prix;
                double valueHT = ((valueWithoutRemise * (100 - pieces_intervention[i].remise)) / 100);
                valeurHT += valueHT;

                myFirstPage.addText(valueHT.ToString(), 540, (lineStartY - 11), predefinedFont.csTimes, 9);
                //myFirstPage.addImage(IconEuros.FullName, 555, (lineStartY - 11));

                lineStartY -= 15;
                lineEndY -= 15;
            }

            #endregion

            #region DETAILS FACTURE BOTTOM
            myFirstPage.drawRectangle(350, 198, 530, 183, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 1, predefinedLineStyle.csNormal);
            myFirstPage.addText("Montant total euros HT", 390, 188, predefinedFont.csTimesBold, 10);
            myFirstPage.drawRectangle(530, 198, 581, 183, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 1, predefinedLineStyle.csNormal);
            myFirstPage.addText(valeurHT.ToString(), 538, 187, predefinedFont.csTimesBold, 10);

            double valueTVA = 0;
            valueTVA = (tva_intervention.valeur_tva / 100) * valeurHT;

            myFirstPage.drawRectangle(350, 183, 530, 168, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 1, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(530, 183, 581, 168, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 1, predefinedLineStyle.csNormal);
            myFirstPage.addText(string.Format("TVA  {0}%", tva_intervention.valeur_tva.ToString()), 420, 173, predefinedFont.csTimesBold, 10, new pdfColor(predefinedColor.csBlack));
            myFirstPage.addText(valueTVA.ToString(), 538, 172, predefinedFont.csTimesBold, 10, new pdfColor(predefinedColor.csBlack));

            myFirstPage.drawRectangle(350, 168, 530, 153, new pdfColor(predefinedColor.csBlack), new pdfColor(218, 150, 148), 1, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(530, 168, 581, 153, new pdfColor(predefinedColor.csBlack), new pdfColor(218, 150, 148), 1, predefinedLineStyle.csNormal);
            myFirstPage.addText("Montant total euros TTC", 390, 158, predefinedFont.csTimesBold, 10, new pdfColor(predefinedColor.csBlack));
            myFirstPage.addText((valueTVA + valeurHT).ToString(), 538, 156, predefinedFont.csTimesBold, 10, new pdfColor(predefinedColor.csBlack));

            /*myFirstPage.drawRectangle(350, 153, 530, 138, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 1, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(530, 153, 581, 138, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 1, predefinedLineStyle.csNormal);
            myFirstPage.addText("Acomptes ", 420, 143, predefinedFont.csTimesBold, 10, new pdfColor(predefinedColor.csBlack));
            myFirstPage.addText(inter.acompte.ToString(), 538, 141, predefinedFont.csTimesBold, 10, new pdfColor(predefinedColor.csBlack));

            myFirstPage.drawRectangle(350, 138, 530, 123, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 1, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(530, 138, 581, 123, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 1, predefinedLineStyle.csNormal);
            myFirstPage.addText("Net à payer", 415, 128, predefinedFont.csTimesBold, 10, new pdfColor(predefinedColor.csBlack));
            myFirstPage.addText((inter.acompte + (valueTVA + valeurHT)).ToString(), 538, 126, predefinedFont.csTimesBold, 10, new pdfColor(predefinedColor.csBlack));*/

            /*myFirstPage.addImage(IconEurosBold.FullName, 564, 187);
            myFirstPage.addImage(IconEurosBold.FullName, 564, 172);
            myFirstPage.addImage(IconEurosBold.FullName, 564, 156);
            myFirstPage.addImage(IconEurosBold.FullName, 564, 141);
            myFirstPage.addImage(IconEurosBold.FullName, 564, 126);*/

            #endregion

            #region ECHEANCES

            myFirstPage.drawRectangle(200, 115, 581, 100, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 1, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(200, 100, 581, 85, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 1, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(200, 100, 290, 85, new pdfColor(predefinedColor.csBlack), new pdfColor(218, 150, 148), 1, predefinedLineStyle.csNormal);
            myFirstPage.addText("Date d'échéance", 210, 90, predefinedFont.csTimesBold, 10, new pdfColor(predefinedColor.csBlack));

            DateTime date_echeance = new DateTime(int.Parse(inter.date_intervention.Substring(6, 4)),int.Parse(inter.date_intervention.Substring(3, 2)),int.Parse(inter.date_intervention.Substring(0, 2)));
            date_echeance.AddDays(30);

            myFirstPage.drawRectangle(290, 100, 415, 85, new pdfColor(predefinedColor.csBlack), new pdfColor(218, 150, 148), 1, predefinedLineStyle.csNormal);
            myFirstPage.addText("Mode de paiement", 311, 90, predefinedFont.csTimesBold, 10, new pdfColor(predefinedColor.csBlack));

            myFirstPage.drawRectangle(415, 100, 581, 85, new pdfColor(predefinedColor.csBlack), new pdfColor(218, 150, 148), 1, predefinedLineStyle.csNormal);
            myFirstPage.addText("Montant de l'échéance", 450, 90, predefinedFont.csTimesBold, 10, new pdfColor(predefinedColor.csBlack));

            myFirstPage.drawRectangle(200, 85, 581, 70, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 1, predefinedLineStyle.csNormal);
            myFirstPage.drawRectangle(200, 85, 290, 70, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 1, predefinedLineStyle.csNormal);
            myFirstPage.addText(mode_paiement.designation, 320, 75, predefinedFont.csTimesBold, 10, new pdfColor(predefinedColor.csBlack));

            myFirstPage.drawRectangle(415, 85, 581, 70, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite), 1, predefinedLineStyle.csNormal);

            myFirstPage.addText(string.Format("{0}/{1}/{2}",date_echeance.Day,date_echeance.Month,date_echeance.Year), 230, 75, predefinedFont.csTimesBold, 10, new pdfColor(predefinedColor.csBlack));
            myFirstPage.addText((valueTVA + valeurHT).ToString(), 490, 75, predefinedFont.csTimesBold, 10, new pdfColor(predefinedColor.csBlack));
            myFirstPage.addText("Récapitulatif des échéances :", 210, 105, predefinedFont.csTimesBold, 10, new pdfColor(predefinedColor.csBlack));
            #endregion

            #region TEXT BOTTOM PAGE
            myFirstPage.addText("Paiement anticipé : aucun escompte accordé.", 20, 40, predefinedFont.csHelvetica, 6);
            myFirstPage.addText("Paiement tardif : une pénalité égale à 3 fois le taux d'intérêt légal et une indemnité pour frais de recouvrement de 40€ sera exigible.", 20, 30, predefinedFont.csHelvetica, 6);
            myFirstPage.addText("SIRET: 801994435 000 15       RCS:  R.C.S VERSAILLES   APE: 4520A      N° TVA: FR 70 801 994 435 000 15       CAPITAL: 1500 EUR   ", 100, 10, predefinedFont.csHelvetica, 7);

            #endregion

            string nomFichier = @"C:\FACTURE\impression_" + DateTime.Now.Millisecond + ".pdf";
            myDoc.createPDF(nomFichier);
        }
    }
}
