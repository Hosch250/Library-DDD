import './App.css'
import {
  loadQuery,
  PreloadedQuery,
  QueryRenderer,
  usePreloadedQuery,
  useQueryLoader,
} from 'react-relay'
import BooksPage from './BooksPage'
import environment from './relay-env'
import type {App_Query} from './__generated__/App_Query.graphql';
import { graphql } from 'babel-plugin-relay/macro';

const query = graphql`
  query App_Query {
    allBooks {
      ...BooksPage_query
    }
  }
`

const preloadedQuery = loadQuery<App_Query>(environment, query, {
  /* query variables */
})

function App() {
  const data = usePreloadedQuery<App_Query>(query, preloadedQuery);

  return (
    <div className="App container">
      <BooksPage query={data.allBooks} />
    </div>
  )
}

function AppRoot() {

  return (
    <QueryRenderer
      environment={environment}
      query={query}
      render={() => <App />}
      variables={{}}
    />
  )
}

export default AppRoot
