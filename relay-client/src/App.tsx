import { QueryRenderer } from 'react-relay'
import BooksPage from './BooksPage'
import environment from './relay-env'
import type {
  App_Query,
  App_Query$data,
} from './__generated__/App_Query.graphql'
import { graphql } from 'babel-plugin-relay/macro'

const query = graphql`
  query App_Query {
    allBooks {
      ...BooksPage_query
    }
  }
`

interface Props {
  error: Error | null
  props: App_Query$data | null
}

function App({ error, props }: Props) {
  if (error) {
    return <div>Error!</div>
  }

  if (!props) {
    return <div>Loading..</div>
  }

  return (
    <div className="App container">
      <BooksPage query={props.allBooks} />
    </div>
  )
}

function AppRoot() {
  return (
    <QueryRenderer<App_Query>
      environment={environment}
      query={query}
      render={(renderProps) => <App {...renderProps} />}
      variables={{}}
    />
  )
}

export default AppRoot
