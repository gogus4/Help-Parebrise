using FirstFloor.ModernUI.App.Content;
using HelpParebrise.Model;
using HelpParebrise.ViewModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HelpParebrise.Data
{
    public class SQLDataHelper
    {
        private MySqlConnection connection;

        public SQLDataHelper()
        {

        }

        private async Task<bool> OpenConnection()
        {
            try
            {
                string myConnectionString = "Database=help_parebrise;Data Source=92.222.162.33;User Id=helpparebrise;Password=helpparebrise";
                connection = new MySqlConnection(myConnectionString);

                connection.Open();

                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private static SQLDataHelper _instance = null;
        public static SQLDataHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SQLDataHelper();
                return _instance;
            }
        }

        #region INTERVENTION
        public async Task<ObservableCollection<Intervention>> getInterventions()
        {
            ObservableCollection<Intervention> _interventions = new ObservableCollection<Intervention>();

            try
            {
                string query = "SELECT * FROM intervention";
                await OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    _interventions.Add(new Intervention()
                    {
                        acompte = double.Parse(dataReader["acompte"].ToString()),
                        cause_sinistre = dataReader["cause_sinistre"].ToString(),
                        date_facture = dataReader["date_facture"].ToString(),
                        date_intervention = dataReader["date_intervention"].ToString(),
                        date_sinistre = dataReader["date_sinistre"].ToString(),
                        franchise = double.Parse(dataReader["franchise"].ToString()),
                        id_tva = int.Parse(dataReader["id_tva"].ToString()),
                        indice_client = int.Parse(dataReader["indice_client"].ToString()),
                        indice_intervention = int.Parse(dataReader["indice_intervention"].ToString()),
                        indice_mode_paiement = int.Parse(dataReader["indice_mode_paiement"].ToString()),
                        indice_prestation = int.Parse(dataReader["indice_prestation"].ToString()),
                        indice_vehicule = int.Parse(dataReader["indice_vehicule"].ToString()),
                        numero_facture = dataReader["numero_facture"].ToString(),
                        prix_HT = double.Parse(dataReader["prix_HT"].ToString()),
                        prix_TTC = double.Parse(dataReader["prix_TTC"].ToString()),
                        remise = double.Parse(dataReader["remise"].ToString()),
                        adresse_intervention = dataReader["adresse_intervention"].ToString()
                    });
                }

                dataReader.Close();
                CloseConnection();
            }
            catch (Exception E) { }

            return _interventions;
        }

        public async Task<bool> deleteIntervention(Intervention _intervention)
        {
            try
            {
                var pieces_intervention = PieceInterventionVM.Instance.PiecesIntervention.Where(x => x.indice_intervention == _intervention.indice_intervention);

                foreach (PieceIntervention piece_inter in pieces_intervention)
                {
                    await SQLDataHelper.Instance.deletePieceIntervention(piece_inter);
                }

                string query = "DELETE FROM intervention WHERE indice_intervention = @indice_intervention";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@indice_intervention", _intervention.indice_intervention);

                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> insertIntervention(Intervention _intervention)
        {
            try
            {
                string query = "INSERT INTO intervention(indice_client,indice_vehicule,date_intervention,date_facture,numero_facture,prix_HT,prix_TTC,id_tva,acompte,remise,franchise,indice_prestation,indice_mode_paiement,date_sinistre,cause_sinistre,adresse_intervention) VALUES(@indice_client,@indice_vehicule,@date_intervention,@date_facture,@numero_facture,@prix_HT,@prix_TTC,@id_tva,@acompte,@remise,@franchise,@indice_prestation,@indice_mode_paiement,@date_sinistre,@cause_sinistre,@adresse_intervention)";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@indice_client", _intervention.indice_client);
                cmd.Parameters.Add("@indice_vehicule", _intervention.indice_vehicule);
                cmd.Parameters.Add("@date_intervention", _intervention.date_intervention);
                cmd.Parameters.Add("@date_facture", _intervention.date_facture);
                cmd.Parameters.Add("@numero_facture", _intervention.numero_facture);
                cmd.Parameters.Add("@prix_HT", _intervention.prix_HT);
                cmd.Parameters.Add("@prix_TTC", _intervention.prix_TTC);
                cmd.Parameters.Add("@id_tva", _intervention.id_tva);
                cmd.Parameters.Add("@acompte", _intervention.acompte);
                cmd.Parameters.Add("@remise", _intervention.remise);
                cmd.Parameters.Add("@franchise", _intervention.franchise);
                cmd.Parameters.Add("@indice_prestation", _intervention.indice_prestation);
                cmd.Parameters.Add("@indice_mode_paiement", _intervention.indice_mode_paiement);
                cmd.Parameters.Add("@date_sinistre", _intervention.date_sinistre);
                cmd.Parameters.Add("@cause_sinistre", _intervention.cause_sinistre);
                cmd.Parameters.Add("@adresse_intervention", _intervention.adresse_intervention);

                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> updateIntervention(Intervention _intervention)
        {
            try
            {
                string query = "UPDATE intervention SET indice_client = @indice_client,indice_vehicule=@indice_vehicule, date_intervention= @date_intervention, date_facture = @date_facture, numero_facture=@numero_facture, prix_HT=@prix_HT, prix_TTC=@prix_TTC, id_tva=@id_tva, acompte=@acompte, remise=@remise, franchise = @franchise, indice_prestation=@indice_prestation, indice_mode_paiement=@indice_mode_paiement, date_sinistre=@date_sinistre, cause_sinistre=@cause_sinistre, adresse_intervention=@adresse_intervention WHERE indice_intervention = @indice_intervention";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@indice_client", _intervention.indice_client);
                cmd.Parameters.Add("@indice_vehicule", _intervention.indice_vehicule);
                cmd.Parameters.Add("@date_intervention", _intervention.date_intervention);
                cmd.Parameters.Add("@date_facture", _intervention.date_facture);
                cmd.Parameters.Add("@numero_facture", _intervention.numero_facture);
                cmd.Parameters.Add("@prix_HT", _intervention.prix_HT);
                cmd.Parameters.Add("@prix_TTC", _intervention.prix_TTC);
                cmd.Parameters.Add("@id_tva", _intervention.id_tva);
                cmd.Parameters.Add("@acompte", _intervention.acompte);
                cmd.Parameters.Add("@remise", _intervention.remise);
                cmd.Parameters.Add("@franchise", _intervention.franchise);
                cmd.Parameters.Add("@indice_prestation", _intervention.indice_prestation);
                cmd.Parameters.Add("@indice_mode_paiement", _intervention.indice_mode_paiement);
                cmd.Parameters.Add("@date_sinistre", _intervention.date_sinistre);
                cmd.Parameters.Add("@cause_sinistre", _intervention.cause_sinistre);
                cmd.Parameters.Add("@adresse_intervention", _intervention.adresse_intervention);
                cmd.Parameters.Add("@indice_intervention", _intervention.indice_intervention);

                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region CUSTOMER
        public async Task<ObservableCollection<Client>> getCustomers()
        {
            ObservableCollection<Client> _customers = new ObservableCollection<Client>();

            try
            {
                string query = "SELECT * FROM client";
                await OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                int ? indice_assurance = 0;

                while (dataReader.Read())
                {
                    if (dataReader["indice_assurance"].ToString() == "")
                        indice_assurance = null;

                    else
                        indice_assurance = int.Parse(dataReader["indice_assurance"].ToString());

                    _customers.Add(new Client()
                    {
                        adresse_email = dataReader["adresse_email"].ToString(),
                        adresse_siege = dataReader["adresse_siege"].ToString(),
                        code_postal = dataReader["code_postal"].ToString(),
                        indice_assurance = indice_assurance,
                        indice_client = int.Parse(dataReader["indice_client"].ToString()),
                        indice_contact = int.Parse(dataReader["indice_contact"].ToString()),
                        nom = dataReader["nom"].ToString(),
                        numero_fax = dataReader["numero_fax"].ToString(),
                        numero_telephone_1 = dataReader["numero_telephone_1"].ToString(),
                        numero_telephone_2 = dataReader["numero_telephone_2"].ToString(),
                        numero_telephone_3 = dataReader["numero_telephone_3"].ToString(),
                        ville = dataReader["ville"].ToString()
                    });
                }

                dataReader.Close();
                CloseConnection();
            }
            catch (Exception E) { }

            return _customers;
        }

        public async Task<bool> updateCustomer(Client _client)
        {
            try
            {
                string query = "UPDATE client SET adresse_siege = @adresse_siege, code_postal = @code_postal, ville = @ville, nom = @nom, indice_contact = @indice_contact, numero_telephone_1 = @numero_telephone_1, numero_telephone_2 = @numero_telephone_2, numero_telephone_3 = @numero_telephone_3, adresse_email = @adresse_email, numero_fax = @numero_fax, indice_assurance = @indice_assurance WHERE indice_client = @indice_client";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@indice_client", _client.indice_client);
                cmd.Parameters.Add("@adresse_siege", _client.adresse_siege);
                cmd.Parameters.Add("@code_postal", _client.code_postal);
                cmd.Parameters.Add("@ville", _client.ville);
                cmd.Parameters.Add("@nom", _client.nom);
                cmd.Parameters.Add("@indice_contact", _client.indice_contact);
                cmd.Parameters.Add("@numero_telephone_1", _client.numero_telephone_1);
                cmd.Parameters.Add("@numero_telephone_2", _client.numero_telephone_2);
                cmd.Parameters.Add("@numero_telephone_3", _client.numero_telephone_3);
                cmd.Parameters.Add("@adresse_email", _client.adresse_email);
                cmd.Parameters.Add("@numero_fax", _client.numero_fax);
                cmd.Parameters.Add("@indice_assurance", _client.indice_assurance);
                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> addCustomer(Client _client)
        {
            try
            {
                string query = "INSERT INTO client(adresse_siege,code_postal,ville,nom,indice_contact,numero_telephone_1,numero_telephone_2,numero_telephone_3,adresse_email,numero_fax,indice_assurance) VALUES(@adresse_siege,@code_postal,@ville,@nom,@indice_contact,@numero_telephone_1,@numero_telephone_2,@numero_telephone_3,@adresse_email,@numero_fax,@indice_assurance)";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@adresse_siege", _client.adresse_siege);
                cmd.Parameters.Add("@code_postal", _client.code_postal);
                cmd.Parameters.Add("@ville", _client.ville);
                cmd.Parameters.Add("@nom", _client.nom);
                cmd.Parameters.Add("@indice_contact", _client.indice_contact);
                cmd.Parameters.Add("@numero_telephone_1", _client.numero_telephone_1);
                cmd.Parameters.Add("@numero_telephone_2", _client.numero_telephone_2);
                cmd.Parameters.Add("@numero_telephone_3", _client.numero_telephone_3);
                cmd.Parameters.Add("@adresse_email", _client.adresse_email);
                cmd.Parameters.Add("@numero_fax", _client.numero_fax);
                cmd.Parameters.Add("@indice_assurance", _client.indice_assurance);
                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> deleteCustomer(Client _customer)
        {
            try
            {
                var interventions = InterventionVM.Instance.Interventions.Where(x => x.indice_client == _customer.indice_client);

                foreach(Intervention inter in interventions)
                {
                    await SQLDataHelper.Instance.deleteIntervention(inter);
                }

                string query = "DELETE FROM client WHERE indice_client = @indice_client";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@indice_client", _customer.indice_client);

                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region ASSURANCE
        public async Task<ObservableCollection<Assurance>> getInsurances()
        {
            ObservableCollection<Assurance> _insurances = new ObservableCollection<Assurance>();

            try
            {
                string query = "SELECT * FROM assurance";
                await OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    _insurances.Add(new Assurance()
                    {
                        adresse = dataReader["adresse"].ToString(),
                        adresse_email = dataReader["adresse_email"].ToString(),
                        code_postal = dataReader["code_postal"].ToString(),
                        indice_assurance = int.Parse(dataReader["indice_assurance"].ToString()),
                        indice_contact = int.Parse(dataReader["indice_contact"].ToString()),
                        nom = dataReader["nom"].ToString(),
                        numero_contrat = dataReader["numero_contrat"].ToString(),
                        numero_fax = dataReader["numero_fax"].ToString(),
                        numero_telephone = dataReader["numero_telephone"].ToString(),
                        ville = dataReader["ville"].ToString()
                    });
                }

                dataReader.Close();
                CloseConnection();
            }
            catch (Exception E) { }

            return _insurances;
        }

        public async Task<bool> insertInsurance(Assurance _assurance)
        {
            try
            {
                string query = "INSERT INTO assurance(nom,adresse,code_postal,ville,numero_telephone,numero_fax,adresse_email,indice_contact,numero_contrat) VALUES(@nom,@adresse,@code_postal,@ville,@numero_telephone,@numero_fax,@adresse_email,@indice_contact,@numero_contrat)";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@nom", _assurance.nom);
                cmd.Parameters.Add("@adresse", _assurance.adresse);
                cmd.Parameters.Add("@code_postal", _assurance.code_postal);
                cmd.Parameters.Add("@ville", _assurance.ville);
                cmd.Parameters.Add("@numero_telephone", _assurance.numero_telephone);
                cmd.Parameters.Add("@numero_fax", _assurance.numero_fax);
                cmd.Parameters.Add("@adresse_email", _assurance.adresse_email);
                cmd.Parameters.Add("@indice_contact", _assurance.indice_contact);
                cmd.Parameters.Add("@numero_contrat", _assurance.numero_contrat);

                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> updateInsurance(Assurance _insurance)
        {
            try
            {
                string query = "UPDATE assurance SET nom = @nom, adresse = @adresse, code_postal = @code_postal, ville = @ville, numero_telephone = @numero_telephone, numero_fax=@numero_fax, adresse_email=@adresse_email, numero_contrat=@numero_contrat WHERE indice_assurance = @indice_assurance";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@nom", _insurance.nom);
                cmd.Parameters.Add("@adresse", _insurance.adresse);
                cmd.Parameters.Add("@code_postal", _insurance.code_postal);
                cmd.Parameters.Add("@ville", _insurance.ville);
                cmd.Parameters.Add("@numero_telephone", _insurance.numero_telephone);
                cmd.Parameters.Add("@numero_fax", _insurance.numero_fax);
                cmd.Parameters.Add("@adresse_email", _insurance.adresse_email);
                cmd.Parameters.Add("@numero_contrat", _insurance.numero_contrat);
                cmd.Parameters.Add("@indice_assurance", _insurance.indice_assurance);

                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region CONTACT
        public async Task<ObservableCollection<Contact>> getContacts()
        {
            ObservableCollection<Contact> _contacts = new ObservableCollection<Contact>();

            try
            {
                string query = "SELECT * FROM contact";
                await OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    _contacts.Add(new Contact()
                    {
                        adresse_email = dataReader["adresse_email"].ToString(),
                        fonction = dataReader["fonction"].ToString(),
                        indice_contact = int.Parse(dataReader["indice_contact"].ToString()),
                        nom = dataReader["nom"].ToString(),
                        numero_fax = dataReader["numero_fax"].ToString(),
                        numero_telephone1 = dataReader["numero_telephone_1"].ToString(),
                        numero_telephone2 = dataReader["numero_telephone_2"].ToString(),
                        prenom = dataReader["prenom"].ToString()
                    });
                }

                dataReader.Close();
                CloseConnection();
            }
            catch (Exception E) { }

            return _contacts;
        }

        public async Task<bool> insertContact(Contact _contact)
        {
            try
            {
                string query = "INSERT INTO contact(nom,prenom,fonction,numero_telephone_1,numero_telephone_2,adresse_email,numero_fax) VALUES(@nom,@prenom,@fonction,@numero_telephone_1,@numero_telephone_2,@adresse_email,@numero_fax)";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@nom", _contact.nom);
                cmd.Parameters.Add("@prenom", _contact.prenom);
                cmd.Parameters.Add("@fonction", _contact.fonction);
                cmd.Parameters.Add("@numero_telephone_1", _contact.numero_telephone1);
                cmd.Parameters.Add("@numero_telephone_2", _contact.numero_telephone2);
                cmd.Parameters.Add("@adresse_email", _contact.adresse_email);
                cmd.Parameters.Add("@numero_fax", _contact.numero_fax);

                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> updateContact(Contact _contact)
        {
            try
            {
                string query = "UPDATE contact SET nom = @nom, prenom = @prenom, fonction=@fonction, numero_telephone_1=@numero_telephone_1, numero_telephone_2=@numero_telephone_2,adresse_email=@adresse_email,numero_fax=@numero_fax WHERE indice_contact=@indice_contact";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@nom", _contact.nom);
                cmd.Parameters.Add("@prenom", _contact.prenom);
                cmd.Parameters.Add("@fonction", _contact.fonction);
                cmd.Parameters.Add("@numero_telephone_1", _contact.numero_telephone1);
                cmd.Parameters.Add("@numero_telephone_2", _contact.numero_telephone2);
                cmd.Parameters.Add("@adresse_email", _contact.adresse_email);
                cmd.Parameters.Add("@numero_fax", _contact.numero_fax);
                cmd.Parameters.Add("@indice_contact", _contact.indice_contact);

                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> deleteContact(Contact _contact)
        {
            try
            {
                string query = "DELETE FROM contact WHERE indice_contact = @indice_contact";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@indice_contact", _contact.indice_contact);

                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region MOYEN DE PAIEMENT
        public async Task<ObservableCollection<ModePaiement>> getPaymentMethod()
        {
            ObservableCollection<ModePaiement> _paymentMethod = new ObservableCollection<ModePaiement>();

            try
            {
                string query = "SELECT * FROM mode_paiement";
                await OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    _paymentMethod.Add(new ModePaiement()
                    {
                        designation = dataReader["designation"].ToString(),
                        indice_mode_paiement = int.Parse(dataReader["indice_mode_paiement"].ToString())
                    });
                }

                dataReader.Close();
                CloseConnection();
            }
            catch (Exception E) { }

            return _paymentMethod;
        }
        #endregion

        #region PIECE
        public async Task<ObservableCollection<Piece>> getPieces()
        {
            ObservableCollection<Piece> _pieces = new ObservableCollection<Piece>();

            try
            {
                string query = "SELECT * FROM piece";
                await OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    _pieces.Add(new Piece()
                    {
                        designation = dataReader["designation"].ToString(),
                        indice_piece = int.Parse(dataReader["indice_piece"].ToString()),
                        prix = double.Parse(dataReader["prix"].ToString()),
                        reference = dataReader["reference"].ToString()
                    });
                }

                dataReader.Close();
                CloseConnection();
            }
            catch (Exception E) { }

            return _pieces;
        }

        public async Task<bool> deletePiece(Piece _piece)
        {
            try
            {
                string query = "DELETE FROM piece WHERE indice_piece = @indice_piece";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@indice_piece", _piece.indice_piece);

                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> updatePiece(Piece _piece)
        {
            try
            {
                string query = "UPDATE piece SET reference = @reference, designation = @designation, prix=@prix WHERE indice_piece=@indice_piece";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@reference", _piece.reference);
                cmd.Parameters.Add("@designation", _piece.designation);
                cmd.Parameters.Add("@prix", _piece.prix);
                cmd.Parameters.Add("@indice_piece", _piece.indice_piece);

                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> insertPiece(Piece _piece)
        {
            try
            {
                string query = "INSERT INTO piece(reference,designation,prix) VALUES(@reference,@designation,@prix)";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@reference", _piece.reference);
                cmd.Parameters.Add("@designation", _piece.designation);
                cmd.Parameters.Add("@prix", _piece.prix);

                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region PIECE INTERVENTION
        public async Task<ObservableCollection<PieceIntervention>> getPiecesIntervention()
        {
            ObservableCollection<PieceIntervention> _piecesIntervention = new ObservableCollection<PieceIntervention>();

            try
            {
                string query = "SELECT * FROM piece_intervention";
                await OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Piece piecevm = PieceVM.Instance.Pieces.Where(x => x.indice_piece.ToString() == dataReader["indice_piece"].ToString()).FirstOrDefault();

                    _piecesIntervention.Add(new PieceIntervention()
                    {
                        indice_intervention = int.Parse(dataReader["indice_intervention"].ToString()),
                        indice_piece = int.Parse(dataReader["indice_piece"].ToString()),
                        indice_piece_intervention = int.Parse(dataReader["indice_piece_intervention"].ToString()),
                        quantite = int.Parse(dataReader["quantite"].ToString()),
                        remise = double.Parse(dataReader["remise"].ToString()),
                        reference = piecevm.reference,
                        prix = piecevm.prix,
                        designation = piecevm.designation
                    });
                }

                dataReader.Close();
                CloseConnection();
            }
            catch (Exception E) { }

            return _piecesIntervention;
        }

        public async Task<bool> insertPieceIntervention(PieceIntervention _pieceIntervention)
        {
            try
            {
                string query = "INSERT INTO piece_intervention(indice_intervention,indice_piece,quantite,remise) VALUES(@indice_intervention,@indice_piece,@quantite,@remise)";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@indice_intervention", _pieceIntervention.indice_intervention);
                cmd.Parameters.Add("@indice_piece", _pieceIntervention.indice_piece);
                cmd.Parameters.Add("@quantite", _pieceIntervention.quantite);
                cmd.Parameters.Add("@remise", _pieceIntervention.remise);

                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> updatePieceIntervention(PieceIntervention _pieceIntervention)
        {
            try
            {
                string query = "UPDATE piece_intervention SET quantite = @quantite, remise = @remise WHERE indice_intervention = @indice_intervention";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@quantite", _pieceIntervention.quantite);
                cmd.Parameters.Add("@remise", _pieceIntervention.remise);
                cmd.Parameters.Add("@indice_intervention", _pieceIntervention.indice_intervention);
                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> deletePieceIntervention(PieceIntervention _pieceIntervention)
        {
            try
            {
                string query = "DELETE FROM piece_intervention WHERE indice_piece_intervention = @indice_piece_intervention";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@indice_piece_intervention", _pieceIntervention.indice_piece_intervention);
                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region TYPE PRESTATION
        public async Task<ObservableCollection<Prestation>> getPrestation()
        {
            ObservableCollection<Prestation> _prestation = new ObservableCollection<Prestation>();

            try
            {
                string query = "SELECT * FROM prestation";
                await OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    _prestation.Add(new Prestation()
                    {
                        designation = dataReader["designation"].ToString(),
                        indice_prestation = int.Parse(dataReader["indice_prestation"].ToString())
                    });
                }

                dataReader.Close();
                CloseConnection();
            }
            catch (Exception E) { }

            return _prestation;
        }
        #endregion

        #region STOCK
        public async Task<ObservableCollection<Stock>> getStock()
        {
            ObservableCollection<Stock> _stock = new ObservableCollection<Stock>();

            try
            {
                string query = "SELECT * FROM stock";
                await OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (PieceVM.Instance.Pieces.Count == 0)
                    PieceVM.Instance.getPieces();

                while (dataReader.Read())
                {
                    Piece piece = PieceVM.Instance.Pieces.Where(x => x.indice_piece.ToString() == dataReader["indice_piece"].ToString()).FirstOrDefault();

                    _stock.Add(new Stock()
                    {
                        indice_piece = int.Parse(dataReader["indice_piece"].ToString()),
                        indice_stock = int.Parse(dataReader["indice_stock"].ToString()),
                        quantite = int.Parse(dataReader["quantite"].ToString()),
                        designation = piece.designation,
                        prix = piece.prix,
                        reference = piece.reference
                    });
                }

                dataReader.Close();
                CloseConnection();
            }
            catch (Exception E) { }

            return _stock;
        }

        public async Task<bool> insertStock(Stock _stock)
        {
            try
            {
                string query = "INSERT INTO stock(indice_piece,quantite) VALUES(@indice_piece,@quantite)";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@indice_piece", _stock.indice_piece);
                cmd.Parameters.Add("@quantite", _stock.quantite);
                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> updateStock(Stock _stock)
        {
            try
            {
                string query = "UPDATE stock SET quantite = @quantite WHERE indice_stock = @indice_stock";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@quantite", _stock.quantite);
                cmd.Parameters.Add("@indice_stock", _stock.indice_stock);
                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region TVA
        public async Task<ObservableCollection<Tva>> getTva()
        {
            ObservableCollection<Tva> _tva = new ObservableCollection<Tva>();

            try
            {
                string query = "SELECT * FROM tva";
                await OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    _tva.Add(new Tva()
                    {
                        id_tva = int.Parse(dataReader["id_tva"].ToString()),
                        valeur_tva = double.Parse(dataReader["valeur_tva"].ToString())
                    });
                }

                dataReader.Close();
                CloseConnection();
            }
            catch (Exception E) { }

            return _tva;
        }
        #endregion

        #region VEHICULE

        public async Task<ObservableCollection<Vehicule>> getVehicule()
        {
            ObservableCollection<Vehicule> _vehicule = new ObservableCollection<Vehicule>();

            try
            {
                string query = "SELECT * FROM vehicule";
                await OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    _vehicule.Add(new Vehicule()
                    {
                        date_mise_en_service = dataReader["date_mise_en_service"].ToString(),
                        immatriculation = dataReader["immatriculation"].ToString(),
                        indice_vehicule = int.Parse(dataReader["indice_vehicule"].ToString()),
                        kilometrage = double.Parse(dataReader["kilometrage"].ToString()),
                        marque = dataReader["marque"].ToString(),
                        modele = dataReader["modele"].ToString(),
                        numero_serie = dataReader["numero_serie"].ToString(),
                        type_vehicule = dataReader["type_vehicule"].ToString()
                    });
                }

                dataReader.Close();
                CloseConnection();
            }
            catch (Exception E) { }

            return _vehicule;
        }

        public async Task<bool> insertVehicule(Vehicule _vehicle)
        {
            try
            {
                string query = "INSERT INTO vehicule(marque,modele,date_mise_en_service,immatriculation,numero_serie,type_vehicule,kilometrage) VALUES(@marque,@modele,@date_mise_en_service,@immatriculation,@numero_serie,@type_vehicule,@kilometrage)";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@marque", _vehicle.marque);
                cmd.Parameters.Add("@modele", _vehicle.modele);
                cmd.Parameters.Add("@date_mise_en_service", _vehicle.date_mise_en_service);
                cmd.Parameters.Add("@immatriculation", _vehicle.immatriculation);
                cmd.Parameters.Add("@numero_serie", _vehicle.numero_serie);
                cmd.Parameters.Add("@type_vehicule", _vehicle.type_vehicule);
                cmd.Parameters.Add("@kilometrage", _vehicle.kilometrage);

                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> updateVehicule(Vehicule _vehicle)
        {
            try
            {
                string query = "UPDATE vehicule SET marque = @marque, modele = @modele, date_mise_en_service = @date_mise_en_service, immatriculation = @immatriculation, numero_serie = @numero_serie, type_vehicule=@type_vehicule, kilometrage=@kilometrage WHERE indice_vehicule = @indice_vehicule";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@marque", _vehicle.marque);
                cmd.Parameters.Add("@modele", _vehicle.modele);
                cmd.Parameters.Add("@date_mise_en_service", _vehicle.date_mise_en_service);
                cmd.Parameters.Add("@immatriculation", _vehicle.immatriculation);
                cmd.Parameters.Add("@numero_serie", _vehicle.numero_serie);
                cmd.Parameters.Add("@type_vehicule", _vehicle.type_vehicule);
                cmd.Parameters.Add("@kilometrage", _vehicle.kilometrage);
                cmd.Parameters.Add("@indice_vehicule", _vehicle.indice_vehicule);

                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region FOURNISSEUR
        public async Task<ObservableCollection<Fournisseur>> getSuppliers()
        {
            ObservableCollection<Fournisseur> _suppliers = new ObservableCollection<Fournisseur>();

            try
            {
                string query = "SELECT * FROM fournisseur";
                await OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    _suppliers.Add(new Fournisseur()
                    {
                        adresse = dataReader["adresse"].ToString(),
                        adresse_email = dataReader["adresse_email"].ToString(),
                        en_cours = double.Parse(dataReader["en_cours"].ToString()),
                        indice_fournisseur = int.Parse(dataReader["indice_fournisseur"].ToString()),
                        nom = dataReader["nom"].ToString(),
                        numero_fax = dataReader["numero_fax"].ToString(),
                        numero_telephone = dataReader["numero_telephone"].ToString(),
                    });
                }

                dataReader.Close();
                CloseConnection();
            }
            catch (Exception E) { }

            return _suppliers;
        }

        public async Task<bool> updateSupplier(Fournisseur _supplier)
        {
            try
            {
                string query = "UPDATE fournisseur SET nom = @nom, adresse = @adresse, numero_telephone = @numero_telephone, adresse_email = @adresse_email, numero_fax = @numero_fax, en_cours=@en_cours WHERE indice_fournisseur = @indice_fournisseur";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@nom", _supplier.nom);
                cmd.Parameters.Add("@adresse", _supplier.adresse);
                cmd.Parameters.Add("@numero_telephone", _supplier.numero_telephone);
                cmd.Parameters.Add("@adresse_email", _supplier.adresse_email);
                cmd.Parameters.Add("@numero_fax", _supplier.numero_fax);
                cmd.Parameters.Add("@en_cours", _supplier.en_cours);
                cmd.Parameters.Add("@indice_fournisseur", _supplier.indice_fournisseur);
                
                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> deleteSupplier(Fournisseur _supplier)
        {
            try
            {
                string query = "DELETE FROM fournisseur WHERE indice_fournisseur = @indice_fournisseur";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@indice_fournisseur", _supplier.indice_fournisseur);

                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> insertSupplier(Fournisseur _supplier)
        {
            try
            {
                string query = "INSERT INTO fournisseur(nom,adresse,numero_telephone,adresse_email,numero_fax,en_cours) VALUES(@nom,@adresse,@numero_telephone,@adresse_email,@numero_fax,@en_cours)";
                await OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();

                cmd.Parameters.Add("@nom", _supplier.nom);
                cmd.Parameters.Add("@adresse", _supplier.adresse);
                cmd.Parameters.Add("@numero_telephone", _supplier.numero_telephone);
                cmd.Parameters.Add("@adresse_email", _supplier.adresse_email);
                cmd.Parameters.Add("@numero_fax", _supplier.numero_fax);
                cmd.Parameters.Add("@en_cours", _supplier.en_cours);

                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}