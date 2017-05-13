using System;

namespace de.brick {

    /**
    Steuert den Ablauf des Algorithmus auf einer abstrakten Ebene.
    */
    public class AblaufSteuerung
    {
        private readonly Population population;

        public AblaufSteuerung(Population population) {
            this.population = population;
        }

        /**
        @startuml
        (*) --> Initialisierung
        --> Fitness
        if "Terminierung?" then
            --> [weiter] Selektion
            --> Kreuzung
            --> Mutation
            --> [nächste Generation] Fitness
        else
            --> [fertig] (*)
        endif
        @enduml        
         */
        public void starten() {
            population.initialisieren();
            population.fitnessTesten();
            while (population.nichtTerminiert()) {
                population.selektiereNeueGeneration();
                population.kreuzeVorfahren();
                population.mutiereChromosom();
            }
        }
    }

    public interface Population
    {
        void fitnessTesten();

        void initialisieren();

        void kreuzeVorfahren();

        void mutiereChromosom();

        bool nichtTerminiert();

        void selektiereNeueGeneration();
    }
}
