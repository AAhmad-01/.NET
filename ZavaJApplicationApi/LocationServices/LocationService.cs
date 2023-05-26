namespace ZavaJApplicationApi.LocationServices
{
    public class LocationService
    {

        private double ToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
        public double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            // Implement your distance calculation algorithm here (e.g., Haversine formula)

            // Example using Haversine formula:
            const double EarthRadiusKm = 6371;
            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = EarthRadiusKm * c;

            return distance;
        }


    }
}
