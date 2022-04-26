import { gql } from '@apollo/client'
import { BooksPageFragment } from '../types-and-hooks'

gql`
  fragment BooksPage on AllBooksConnection {
    nodes {
      id
      isbn
      name
    }
  }
`

interface Props {
  query: BooksPageFragment | null
}

function BooksPage({ query }: Props) {
  return (
    <div className="BooksPage">
      {query?.nodes?.map((m) => (
        <div key={m.id}>
          {m.name} - {m.isbn}
        </div>
      ))}
    </div>
  )
}

export default BooksPage
