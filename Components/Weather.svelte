<script>
  import axios from 'axios';

  const url = 'https://api.weather.gov/stations/KCOQ/observations/latest';

  let temp = '';

  const getWeather = async () => {
    try {
      const result = await axios.get(url);
      temp = result.data.properties.temperature.value;
    } catch (error) {
      console.log(error);
    }
  }
</script>

<button on:click={getWeather}>
  Get weather
</button>
<code>
  { temp }
</code>
