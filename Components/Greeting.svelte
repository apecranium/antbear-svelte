<script>
    import axios from 'axios';
  
    const url = '/api/home';
  
    let greeting = '';
  
    const getGreeting = async () => {
      try {
        const response = await axios.get(url);
        greeting = response.data;
      } catch (error) {
        console.log(error);
      }
    }
  </script>
  
  <button on:click={getGreeting}>
    Get greeting
  </button>
  <code>
    { greeting }
  </code>
  