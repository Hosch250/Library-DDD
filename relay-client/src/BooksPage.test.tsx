import BooksPage from './BooksPage'
import { createMockEnvironment, MockPayloadGenerator } from 'relay-test-utils'
import ReactTestRenderer from 'react-test-renderer'
import { RelayEnvironmentProvider, useLazyLoadQuery } from 'react-relay'
import { graphql } from 'babel-plugin-relay/macro'
import { Suspense } from 'react'
import { BooksPage_TestQuery } from './__generated__/BooksPage_TestQuery.graphql'

test('Renders book names', () => {
  const environment = createMockEnvironment()
  environment.mock.queueOperationResolver((operation) =>
    MockPayloadGenerator.generate(operation, {
      AllBooksConnection() {
        return {
          __typename: 'AllBooksConnection',
          nodes: [
            {
              id: '1',
              isbn: '123-123456789',
              name: 'Book 1',
            },
            {
              id: '2',
              isbn: '987-123456789',
              name: 'Book 2',
            },
          ],
        }
      },
    }),
  )

  const TestRenderer = () => {
    const data = useLazyLoadQuery<BooksPage_TestQuery>(
      graphql`
        query BooksPage_TestQuery @relay_test_operation {
          allBooks {
            ...BooksPage_query
          }
        }
      `,
      {},
    )

    return <BooksPage query={data.allBooks} />
  }

  const renderer = ReactTestRenderer.create(
    <RelayEnvironmentProvider environment={environment}>
      <Suspense fallback="Loading...">
        <TestRenderer />
      </Suspense>
    </RelayEnvironmentProvider>,
  )
  
  expect(renderer).toMatchSnapshot()
})
