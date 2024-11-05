async function fetchNodesAsync() {
  return await fetch('http://localhost:25052/nodes')
  .then(response => response.json())
  .catch(error => console.error('Error fetching nodes:', error));
}

export {
  fetchNodesAsync
};
