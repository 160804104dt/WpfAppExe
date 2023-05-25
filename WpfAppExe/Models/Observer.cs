using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppExe.Models
{
    public abstract class Observer
    {
        public Subject Subject;
        public abstract void Update();
    }

    public class BinaryObserver : Observer
    {
        public BinaryObserver()
        {

        }

        public BinaryObserver(Subject subject)
        {
            subject.AddObserver(this);
        }

        public override void Update()
        {
            System.Diagnostics.Debug.WriteLine($"Binary String: {Convert.ToString(Subject.State, 2)}");
        }
    }

    public class OctalObserver : Observer
    {
        public OctalObserver()
        {

        }

        public OctalObserver(Subject subject)
        {
            subject.AddObserver(this);
        }

        public override void Update()
        {
            System.Diagnostics.Debug.WriteLine($"Octal String: {Convert.ToString(Subject.State, 8)}");
        }
    }

    public class HexaObserver : Observer
    {
        public HexaObserver()
        {

        }

        public HexaObserver(Subject subject)
        {
            subject.AddObserver(this);
        }

        public override void Update()
        {
            System.Diagnostics.Debug.WriteLine($"Hex String: {Convert.ToString(Subject.State, 16)}");
        }
    }

}
