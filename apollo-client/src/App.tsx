import { ApolloProvider, gql } from '@apollo/client'
import { useAppQuery } from './types-and-hooks'
import { client } from './client'
import BooksPage from './BooksPage'
import CreateUser from './CreateUser'

gql`
  query App {
    allBooks {
      ...BooksPage
    }
  }
`

export function App() {
  const { data, loading, error } = useAppQuery()

  if (error) {
    return <div>Error!</div>
  }

  if (loading) {
    return <div>Loading...</div>
  }

  return (
    <div className="App container">
      <CreateUser />
      <BooksPage data={data?.allBooks} />
    </div>
  )
}

function AppRoot() {
  return (
    <ApolloProvider client={client}>
      <App />
    </ApolloProvider>
  )
}

export default AppRoot
