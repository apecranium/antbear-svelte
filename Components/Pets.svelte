<script>
  import axios from 'axios';

  const url = '/api/pets';

  let pets = '';

  const getPets = async () => {
    try {
      const response = await axios.get(url);
      pets = JSON.stringify(response.data);
    } catch (error) {
      console.log(error);
    }
  }
</script>

<div>
  <button on:click={getPets}>
    Get pets
  </button>
</div>
<div>
  <code>
    { pets }
  </code>
</div>
