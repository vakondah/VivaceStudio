using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Models
{
    public interface IInstrumentRepository
    {
        public IEnumerable<Instrument> GetInstruments { get; }
        Instrument GetInstrumentById(int instrumentId);
    }
}
