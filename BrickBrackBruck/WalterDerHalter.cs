using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


namespace BrickBrackBruck
{

    class WalterDerHalter
    {
        List<Ding> dinger = new List<Ding>();        

        DateTime tag0 = new DateTime(1990,01,01);


        public bool VerzeichnisHinzufügen(string pfad)
        {
            try
            {
                string[] Files = System.IO.Directory.GetFiles(pfad);

                foreach (string f in Files)
                {
                    if (!DingHinzufügen( f ))
                        return false;
                }  
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler (VerzeichnisHinzufügen): " + ex.Message);   
                return false;
            }

            return true;                
        }

        private bool DingHinzufügen(string datei)
        {
            try
            {
                int nameBeginn = datei.IndexOf("table_") + 6;
                string name = datei.Substring(nameBeginn, datei.Length - nameBeginn - 4);
                string[] zeilen = File.ReadAllLines( datei );

                // tag0 ist der kleinste index
                // heute ist der größte index
                Ding d = new Ding( name, TagZuIndex(DateTime.Now)+1 );          

                int letzterGültigerIndex = -1;

                // setzt pro zeile alle vorhandenen tage
                // nicht vorhandene bleiben null
                for( int i=zeilen.Length-1; i > 0; i--)
                {
                    string[] felder = zeilen[i].Split(',');


                    int tIndex = TagZuIndex( DateTime.Parse( felder[0]) );

                    d.werte[tIndex] = Double.Parse(felder[4].Replace('.', ','));                    
                    d.volumina[tIndex] =  Int32.Parse( felder[5] );

                    // todo ...
                    // alle anderen werte mitnehmen ( High, low, angepasster endwert)   

                    // berechnet die änderung ab dem ersten
                    if ( i < zeilen.Length - 1)
                        d.änderungen[tIndex] = (double)d.werte[tIndex] - (double)d.werte[letzterGültigerIndex];               


                    // statistisches beiwerk
                    if ( i==zeilen.Length-1 ) d.kleinsterIndex = tIndex;
                    if ( i==1 ) d.grössterIndex = tIndex;
                    if ( letzterGültigerIndex + 1 != tIndex) 
                        d.NichtFolgendeÄnderungen++;   // feiertage + wochenenden

                    letzterGültigerIndex = tIndex;
                }

                d.gültigeWerte = zeilen.Length;
                

                dinger.Add( d );
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler (DingHinzufügen) Datei: " + datei + "\r\nException: " + ex.Message);   
                return false;
            }

            return true;
        }

        public void hoseRunter()
        {
            Console.WriteLine("Walter: Dinger au'n Tisch:");

            Console.WriteLine("gültige\t minIdx\t maxIdx\t nfÄnd\t Name" );    

            foreach( Ding d in dinger)
            {
                Console.WriteLine(  d.gültigeWerte + "\t " +
                                    d.kleinsterIndex + "\t " +
                                    d.grössterIndex + "\t " +
                                    d.NichtFolgendeÄnderungen + "\t " +
                                    d.bezeichnung  );    
            }
        }

        private int TagZuIndex( DateTime tag)
        {
            return (tag - tag0).Days;     
        }

        public DateTime IndexZuTag(int index)
        {
            return tag0.AddDays(index);
        }
    }
}