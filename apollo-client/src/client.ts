import {
  ApolloClient,
  ApolloLink,
  HttpLink,
  InMemoryCache,
} from '@apollo/client'
import envs from './env'

const httpLink = new HttpLink({
  uri: envs.GraphQLEndpoint,
})

export const client = new ApolloClient({
  cache: new InMemoryCache(),
  link: ApolloLink.from([httpLink]),
})
