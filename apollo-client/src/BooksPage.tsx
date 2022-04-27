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
  data?: BooksPageFragment | null
}

function BooksPage({ data }: Props) {
  return (
    <div className="BooksPage">
      {data?.nodes?.map((m) => (
        <div key={m.id}>
          {m.name} - {m.isbn}
        </div>
      ))}
    </div>
  )
}

export default BooksPage
