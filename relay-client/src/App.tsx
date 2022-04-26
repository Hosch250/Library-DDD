import { Environment, QueryRenderer } from 'react-relay'
import BooksPage from './BooksPage'
import defaultEnvironment from './relay-env'
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

export function App({ error, props }: Props) {
  if (error) {
    return <div>Error!</div>
  }

  if (!props) {
    return <div>Loading...</div>
  }

  return (
    <div className="App container">
      <BooksPage query={props.allBooks} />
    </div>
  )
}

export interface AppRootProps {
  environment?: Environment
}

function AppRoot({ environment }: AppRootProps) {
  return (
    <QueryRenderer<App_Query>
      environment={environment ?? defaultEnvironment}
      query={query}
      render={(renderProps) => <App {...renderProps} />}
      variables={{}}
    />
  )
}

export default AppRoot
