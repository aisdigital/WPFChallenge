using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Xml;
using WpfChallenge.Model;

namespace WpfChallenge.Controller
{    
    public class CostumerController
    {
        private string pathXmlCostumer = AppDomain.CurrentDomain.BaseDirectory + @"..\..\Data\Costumers.xml";

        public Costumer getCostumer(int id)
        {
            try
            {
                DataSet dsResult = new DataSet();
                dsResult.ReadXml(pathXmlCostumer);
                if (dsResult.Tables.Count != 0)
                {
                    foreach (DataRow dr in dsResult.Tables[0].Rows)
                    {
                        if (dr["id"].ToString() == id.ToString())
                        {
                            return new Costumer()
                            {
                                id = dr["id"].ToString(),
                                Name = dr["Name"].ToString(),
                                Email = dr["Email"].ToString(),
                                Phone = dr["Phone"].ToString(),
                                Address = dr["Address"].ToString()
                            };
                        }
                    }

                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Costumer> getAllCostumer()
        {
            List<Costumer> Costumers = new List<Costumer>(); 
            try
            {
                DataSet dsResult = new DataSet();
                dsResult.ReadXml(pathXmlCostumer);
                if (dsResult.Tables.Count != 0)
                {
                    foreach (DataRow dr in dsResult.Tables[0].Rows)
                    {
                        Costumers.Add(new Costumer()
                        {
                            id = dr["id"].ToString(),
                            Name = dr["Name"].ToString(),
                            Email = dr["Email"].ToString(),
                            Phone = dr["Phone"].ToString(),
                            Address = dr["Address"].ToString()
                        });
                    }
                   
                }
                return Costumers;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool saveCostumer(Costumer costumer)
        {
            if (!validateCostumer(costumer))
            {
                return false;
            }
            try
            {
                using (DataSet dsResult = new DataSet())
                {
                    dsResult.ReadXml(pathXmlCostumer);
                    if (dsResult.Tables.Count == 0)
                    {
                        //New Instance                       
                        XmlTextWriter writer = new XmlTextWriter(pathXmlCostumer, System.Text.Encoding.UTF8);
                        writer.WriteStartDocument(true);
                        writer.Formatting = Formatting.Indented;
                        writer.Indentation = 2;
                        writer.WriteStartElement("Costumers");
                        writer.WriteStartElement("Costumer");
                        writer.WriteStartElement("id");
                        writer.WriteString("1");
                        writer.WriteEndElement();
                        writer.WriteStartElement("Name");
                        writer.WriteString(costumer.Name);
                        writer.WriteEndElement();
                        writer.WriteStartElement("Email");
                        writer.WriteString(costumer.Email);
                        writer.WriteEndElement();
                        writer.WriteStartElement("Phone");
                        writer.WriteString(costumer.Phone);
                        writer.WriteEndElement();
                        writer.WriteStartElement("Address");
                        writer.WriteString(costumer.Address);
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Close();
                        dsResult.ReadXml(pathXmlCostumer);
                    }
                    else
                    {
                        //add in DataSet
                        dsResult.Tables[0].Rows.Add(dsResult.Tables[0].NewRow());
                        dsResult.Tables[0].Rows[dsResult.Tables[0].Rows.Count - 1]["id"] = nextCostumerVal();
                        dsResult.Tables[0].Rows[dsResult.Tables[0].Rows.Count - 1]["Name"] = costumer.Name;
                        dsResult.Tables[0].Rows[dsResult.Tables[0].Rows.Count - 1]["Email"] = costumer.Email;
                        dsResult.Tables[0].Rows[dsResult.Tables[0].Rows.Count - 1]["Phone"] = costumer.Phone;
                        dsResult.Tables[0].Rows[dsResult.Tables[0].Rows.Count - 1]["Address"] = costumer.Address;
                        dsResult.AcceptChanges();
                        //--  Write XML
                        dsResult.WriteXml(pathXmlCostumer, XmlWriteMode.IgnoreSchema);
                    }
                    MessageBox.Show("Operation performed successfully");
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
                return false;
            }

        }

        public bool editCostumer(Costumer costumer)
        {
            if(!validateCostumer(costumer))
            {
                return false;
            }
            try
            {
                using (DataSet dsResult = new DataSet())
                {
                    dsResult.ReadXml(pathXmlCostumer);
                    if (dsResult.Tables.Count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        //remove in DataSet
                        foreach (DataRow dr in dsResult.Tables[0].Rows)
                        {
                            if (dr["id"].ToString() == costumer.id)
                            {
                                dr["Name"] = costumer.Name;
                                dr["Email"] = costumer.Email;
                                dr["Phone"] = costumer.Phone;
                                dr["Address"] = costumer.Address;
                            }
                        }
                        dsResult.AcceptChanges();
                        //--  Write XML
                        dsResult.WriteXml(pathXmlCostumer, XmlWriteMode.IgnoreSchema);
                    }
                    MessageBox.Show("Operation performed successfully");
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
                return false; 
            }
        }
        public bool deleteCostumer(int id)
        {
            try
            {
                using (DataSet dsResult = new DataSet())
                {
                    dsResult.ReadXml(pathXmlCostumer);
                    if (dsResult.Tables.Count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        //remove in DataSet
                        foreach (DataRow dr in dsResult.Tables[0].Rows)
                        {
                            if (dr["id"].ToString() == id.ToString())
                            {
                                dsResult.Tables[0].Rows.Remove(dr);
                                break;
                            }
                        }
                        dsResult.AcceptChanges();
                        //--  Write XML
                        dsResult.WriteXml(pathXmlCostumer, XmlWriteMode.IgnoreSchema);
                    }
                    MessageBox.Show("Operation performed successfully");
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
                return false;
            }

        }

        private int nextCostumerVal()
        {
            try
            {
                using (DataSet dsResult = new DataSet())
                {
                    dsResult.ReadXml(pathXmlCostumer);                    
                    return int.Parse(dsResult.Tables[0].Rows[dsResult.Tables[0].Rows.Count - 1]["id"].ToString()) + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
                return 1;
            }
        }

        private bool validateCostumer(Costumer costumer)
        {
            if(string.IsNullOrEmpty(costumer.Name))
            {
                MessageBox.Show("Name Field is Required!");
                return false;
            }

            if (string.IsNullOrEmpty(costumer.Email))
            {
                MessageBox.Show("E-mail Field is Required!");
                return false;
            }

            if (string.IsNullOrEmpty(costumer.Phone))
            {
                MessageBox.Show("Phone Number Field is Required!");
                return false;
            }

            if (string.IsNullOrEmpty(costumer.Address))
            {
                MessageBox.Show("Adress Field is Required!");
                return false;
            }

            return true;
        }
    }
}
