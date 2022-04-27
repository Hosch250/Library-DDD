import { gql } from '@apollo/client'
import { useAppQuery } from '../types-and-hooks'
import BooksPage from './BooksPage'

gql`
  query App {
    allBooks {
      ...BooksPage
    }
  }
`

function App() {
  const { data, loading, error } = useAppQuery()

  if (error) {
    return <div>Error!</div>
  }

  if (loading) {
    return <div>Loading...</div>
  }

  return (
    <div className="App container">
      <BooksPage data={data?.allBooks} />
    </div>
  )
}

export default App
