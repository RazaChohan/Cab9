using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Prototype
{
    public class getCoordinatesFromLocation
    {
        GeoCoordinate geo = new GeoCoordinate();
        public GeoCoordinate corrdinatioes(string Location)
        {
            try
            {
                string result = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=true", Location);

                var doc = XDocument.Load(result);
                string status = doc.Element("GeocodeResponse").Element("status").Value;
             
                if (status.Equals("OK"))
                {
                    var point = doc.Element("GeocodeResponse").Element("result").
                   Element("geometry").Element("location");

                    string lat = point.Element("lat").Value;
                    string lng = point.Element("lng").Value;
                    double dlat = (float)Convert.ToDouble(lat);
                    double dlng = (float)Convert.ToDouble(lng);
                    geo.Latitude = Math.Round(dlat,2);
                    geo.Longitude = Math.Round(dlng,2);
                    return geo;
                }
                else if (status.Equals("ZERO_RESULTS"))
                {
                    return null;

                }
                else if (status.Equals("REQUEST_DENIED"))
                {
                    return null;
                }
                else if (status.Equals("INVALID_REQUEST"))
                {
                    return null;
                }
                else if (status.Equals("UNKNOWN_ERROR"))
                {
                    return null;
                }
                return geo;
            }
            catch (Exception ed)
            {
                
            }
            return geo;
        }
    }
}
