using BasarDemoDx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetTopologySuite;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using OSGeo.OGR;

namespace BasarDemoDx
{
    static class Program
    {
        public static DbConnectionModel dbModel { get; set; }
        public static MainForm mainForm { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var gss = new NtsGeometryServices();
            var css = new SharpMap.CoordinateSystems.CoordinateSystemServices(
                new CoordinateSystemFactory(),
                new CoordinateTransformationFactory(),
                SharpMap.Converters.WellKnownText.SpatialReference.GetAllReferenceSystems());

            // plug-in WebMercator so that correct spherical definition is directly available to Layer Transformations using SRID
            var pcs = (ProjectedCoordinateSystem)ProjectedCoordinateSystem.WebMercator;
            css.AddCoordinateSystem((int)pcs.AuthorityCode, pcs);

            GeoAPI.GeometryServiceProvider.Instance = gss;
            SharpMap.Session.Instance
                .SetGeometryServices(gss)
                .SetCoordinateSystemServices(css)
                .SetCoordinateSystemRepository(css);

            //Ogr.RegisterAll();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new MainForm();
            Application.Run(mainForm);
        }
    }
}
