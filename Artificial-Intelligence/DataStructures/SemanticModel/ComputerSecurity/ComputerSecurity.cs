using ArtificialIntelligence.DataStructures.SemanticModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artificial_Intelligence.DataStructures.SemanticModel.ComputerSecurity
{
    internal static class ComputerSecurity
    {


        public static void Test()
        {
            Knowledge knowledge = GetKnowledge();
            int deep = 2;
            int customTab = 4;

            Show(0, 2, knowledge.DoctorPrograms);

        }

        public static void Show(int level, int deep, Entity selectedEntity)
        {
            int customTab = 6;

            while (level != deep)
            {
                Console.WriteLine($"{"".PadLeft(level * customTab)}{selectedEntity.Name}");
                foreach (var relation in selectedEntity.Relations)
                {
                    Console.WriteLine($"{"".PadLeft(level * customTab + 4)}{relation.Predicate} : {relation.Entity.Name}");
                }

                level++;

                foreach (var relation in selectedEntity.Relations)
                {
                    Show(level, deep, relation.Entity);
                }
            }
        }

        public static Knowledge GetKnowledge()
        {
            Knowledge knowledge = new Knowledge();

            knowledge.Software.Relations.AddLast(new Relation()
            {
                Predicate = "включает",
                Entity = knowledge.ProgramsCollection
            });

            knowledge.VaccinePorograms.Relations.AddLast(new Relation()
            {
                Predicate = "являются",
                Entity = knowledge.AntivirusPrograms
            });

            knowledge.AntivirusPrograms.Relations.AddLast(new Relation()
            {
                Predicate = "имеют свойство",
                Entity = knowledge.DetectSoftwareViruses
            });

            knowledge.AntivirusPrograms.Relations.AddLast(new Relation()
            {
                Predicate = "относится",
                Entity = knowledge.Software
            });

            knowledge.AntivirusPrograms.Relations.AddLast(new Relation()
            {
                Predicate = "являются",
                Entity = knowledge.AuxiliaryPurposePrograms
            });

            knowledge.AntivirusPrograms.Relations.AddLast(new Relation()
            {
                Predicate = "предназначены",
                Entity = knowledge.ProtectInformationFromComputerViruses
            });

            knowledge.ProgramsFilters.Relations.AddLast(new Relation()
            {
                Predicate = "являются",
                Entity = knowledge.AntivirusPrograms
            });

            knowledge.AuditPrograms.Relations.AddLast(new Relation()
            {
                Predicate = "являются",
                Entity = knowledge.AntivirusPrograms
            });

            knowledge.DoctorPrograms.Relations.AddLast(new Relation()
            {
                Predicate = "являются",
                Entity = knowledge.AntivirusPrograms
            });

            knowledge.DoctorPrograms.Relations.AddLast(new Relation()
            {
                Predicate = "имеют свойство",
                Entity = knowledge.DetectKnownViruses
            });

            knowledge.DoctorWeb.Relations.AddLast(new Relation()
            {
                Predicate = "являются",
                Entity = knowledge.DoctorPrograms
            });

            knowledge.NortonAntiVirus.Relations.AddLast(new Relation()
            {
                Predicate = "является",
                Entity = knowledge.DoctorPrograms
            });

            knowledge.Avast.Relations.AddLast(new Relation()
            {
                Predicate = "является",
                Entity = knowledge.DoctorPrograms
            });

            knowledge.NOD32.Relations.AddLast(new Relation()
            {
                Predicate = "различает",
                Entity = knowledge.NOD32251
            });

            knowledge.NOD32.Relations.AddLast(new Relation()
            {
                Predicate = "различает",
                Entity = knowledge.NOD3227
            });

            knowledge.NOD32.Relations.AddLast(new Relation()
            {
                Predicate = "является",
                Entity = knowledge.DetectorPrograms
            });

            knowledge.DetectorPrograms.Relations.AddLast(new Relation()
            {
                Predicate = "имеют свойство",
                Entity = knowledge.AntivirusPrograms
            });

            knowledge.DetectorPrograms.Relations.AddLast(new Relation()
            {
                Predicate = "имеют свойство",
                Entity = knowledge.FindPopularViruses
            });

            return knowledge;
        }
    }
}