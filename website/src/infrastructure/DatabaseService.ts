const dbAddress = 'http://localhost:25052/';

async function fetchDataAsync(slug: string) {
  console.log('fetching data:', dbAddress + slug);
  return await fetch(dbAddress + slug)
  .then(response => response.json())
  .catch(error => console.error('Error fetching data:', dbAddress + slug, error));
}

export {
  fetchDataAsync
};
