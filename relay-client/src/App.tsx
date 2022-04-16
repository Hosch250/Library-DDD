import './App.css'
import {
  graphql,
  PreloadedQuery,
  QueryRenderer,
  usePreloadedQuery,
  useQueryLoader,
} from 'react-relay'
import BooksPage from './BooksPage'
import environment from './relay-env'
import type {App_Query} from './__generated__/App_Query.graphql';

const query = graphql`
  query App_Query {
    allBooks {
      ...BooksPage_query
    }
  }
`

interface Props {
  preloadedQuery: PreloadedQuery<App_Query>
}

// const preloadedQuery = loadQuery<AppQueryType>(environment, query, {
//   /* query variables */
// })

function App({ preloadedQuery }: Props) {
  //const data = usePreloadedQuery(query, preloadedQuery)
  const data = usePreloadedQuery<App_Query>(query, preloadedQuery);

  return (
    <div className="App container">
      <BooksPage query={data.allBooks} />
    </div>
  )
}

function AppRoot() {
  const [queryReference, loadQuery] = useQueryLoader<App_Query>(
    query
  );

  loadQuery({})

  return (
    <QueryRenderer
      environment={environment}
      query={query}
      render={() => queryReference && <App preloadedQuery={queryReference} />}
      variables={{}}
    />
  )
}

export default AppRoot
