
using System.Collections.Generic;
using System.Collections;

class Ding
    {
        public string bezeichnung;

        public ArrayList werte = new ArrayList();
        public ArrayList änderungen = new ArrayList();
        public ArrayList volumina = new ArrayList();
        
        // statistisches zeugs
        public int gültigeWerte = 0;
        public int kleinsterIndex = -1;
        public int grössterIndex = -1;
        public int NichtFolgendeÄnderungen = 0;
        
        public Ding(string bezeichnung, int länge) 
        {
            this.bezeichnung = bezeichnung;
            erweitern( länge );
        }

        public void erweitern( int neueLänge )
        {
            int diff = neueLänge - werte.Count;

            erweitereAL( werte, diff);
            erweitereAL( änderungen, diff);
            erweitereAL( volumina, diff);
        }        

        private void erweitereAL(ArrayList al, int länge)
        {
            for(int i=0; i<länge; i++)
                al.Add(null);
        }
    }