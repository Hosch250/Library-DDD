import { useFragment } from 'react-relay'
import { BooksPage_query$key } from './__generated__/BooksPage_query.graphql'
import { graphql } from 'babel-plugin-relay/macro';

interface Props {
  query: BooksPage_query$key | null
}

function BooksPage({ query }: Props) {
  const data = useFragment(
    graphql`
      fragment BooksPage_query on AllBooksConnection {
        nodes {
          id
          isbn
          name
        }
      }
    `,
    query,
  )

  return (
    <div className="BooksPage">
      {data?.nodes?.map(m => (
        <div key={m.id}>
          {m.name} - {m.isbn}
        </div>
      ))}
    </div>
  )
}

export default BooksPage

// export default createFragmentContainer(BooksPage, {
//   query: graphql`
//     fragment BooksPage_query on RepositoryOwner {
//       repositories(first: 25, orderBy: { field: CREATED_AT, direction: DESC }) {
//         nodes {
//           name
//           stargazerCount
//           isFork
//         }
//       }
//     }
//   `,
// })
