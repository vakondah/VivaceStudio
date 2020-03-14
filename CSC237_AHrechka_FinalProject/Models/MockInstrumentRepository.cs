using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Models
{
    public class MockInstrumentRepository : IInstrumentRepository
    {
        public IEnumerable<Instrument> GetInstruments => 
            new List<Instrument>
            { 
                new Instrument
                {
                    InstrumentID = 1,
                    InstrumentName = "Guitar"
                },
                new Instrument
                {
                    InstrumentID = 2,
                    InstrumentName = "Piano"
                },
                new Instrument
                {
                    InstrumentID = 3,
                    InstrumentName = "Violin"
                },
                new Instrument
                {
                    InstrumentID = 4,
                    InstrumentName = "Chello"
                },
                new Instrument
                {
                    InstrumentID = 5,
                    InstrumentName = "Saxophone"
                },
                new Instrument
                {
                    InstrumentID = 6,
                    InstrumentName = "Triangle"
                }
            };

        public Instrument GetInstrumentById(int instrumentId)
        {
            return GetInstruments.FirstOrDefault(i => i.InstrumentID == instrumentId);
        }
    }
}
