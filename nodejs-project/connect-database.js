'use strict'
const { Client } = require('cassandra-driver');

async function run() {
  const client = new Client({
    cloud: { secureConnectBundle: 'secure-connect-db-test.zip' },
    credentials: { username: 'zutjmx', password: 'Proxmox5' }
  });

  await client.connect();

  // Execute a query
  const rs = await client.execute('SELECT * FROM system.local');
  console.log(`Hello from cluster: ${rs.first()['cluster_name']}`);

  await client.shutdown();
}

// Run the async function
run();
