import './App.css'
import { gql } from '@apollo/client'
import { useAppQuery } from '../types-and-hooks'

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
    return <div>Loading..</div>
  }

  return (
    <div className="App container">
      <BooksPage query={data.allBooks} />
    </div>
  )
}

export default App
