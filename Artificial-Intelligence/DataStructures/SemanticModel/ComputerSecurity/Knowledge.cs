using ArtificialIntelligence.DataStructures.SemanticModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Artificial_Intelligence.DataStructures.SemanticModel.ComputerSecurity
{
    internal sealed class Knowledge
    {
        public Entity DetectSoftwareViruses { get; set; } = new Entity("Обнаруживают программные вмрусы");
        public Entity Software { get; set; } = new Entity("Программное обеспечение");
        public Entity ProgramsCollection { get; set; } = new Entity("Набор программ");
        public Entity VaccinePorograms { get; set; } = new Entity("Программы-вакцины");
        public Entity AntivirusPrograms { get; set; } = new Entity("Антивирусные программы");
        public Entity AuxiliaryPurposePrograms { get; set; } = new Entity("Программы вспомогательного назначения");
        public Entity ProgramsFilters { get; set; } = new Entity("Программы фильтры");
        public Entity ProtectInformationFromComputerViruses { get; set; } = new Entity("Для защиты информации компьютерных вирусов");
        public Entity AuditPrograms { get; set; } = new Entity("Программы ревизоры");
        public Entity DetectKnownViruses { get; set; } = new Entity("Обнаруживают известные вирусы");
        public Entity FindPopularViruses { get; set; } = new Entity("Находят вирусы и лечат");
        public Entity DoctorPrograms { get; set; } = new Entity("Программы-доктора");
        public Entity DetectorPrograms { get; set; } = new Entity("Программы детекторы");
        public Entity NortonAntiVirus { get; set; } = new Entity("Norton AntiVirus");
        public Entity DoctorWeb { get; set; } = new Entity("DoctorWeb");
        public Entity NOD32 { get; set; } = new Entity("NOD32");
        public Entity Avast { get; set; } = new Entity("Avast");
        public Entity NOD3227 { get; set; } = new Entity("NOD32.2.7");
        public Entity NOD32251 { get; set; } = new Entity("NOD32.2.51");

        public List<Entity> ToList()
        {
            List<Entity> list = new List<Entity>();

            foreach (PropertyInfo property in typeof(Knowledge).GetProperties())
            {
                list.Add((Entity)property.GetValue(this));
            }

            return list;
        }
    }
}
