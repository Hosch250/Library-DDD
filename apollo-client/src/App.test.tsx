import { AppDocument, BooksPageFragment } from './types-and-hooks'
import { App } from './App'
import { MockedProvider, MockedResponse } from '@apollo/client/testing'
import { screen, render, act } from '@testing-library/react'

const mocks: MockedResponse[] = [
  {
    request: {
      query: AppDocument,
    },
    result: {
      data: {
        allBooks: {
          __typename: 'AllBooksConnection',
          nodes: [
            {
              __typename: 'Book',
              id: 1,
              isbn: '978-1617294532',
              name: 'C# In Depth, Fourth Edition',
            },
            {
              __typename: 'Book',
              id: 2,
              isbn: '978-1617295683',
              name: 'GraphQL in Action',
            },
          ] as BooksPageFragment,
        },
      },
    },
  },
]

const errMocks: MockedResponse[] = [
  {
    request: {
      query: AppDocument,
    },
    error: new Error('An error occurred'),
  },
]

it('renders loading state', () => {
  render(
    <MockedProvider mocks={mocks}>
      <App />
    </MockedProvider>,
  )

  const domPiece = screen.getByText('Loading...')
  expect(domPiece).toBeInTheDocument()
})

it('renders book list', async () => {
  render(
    <MockedProvider mocks={mocks}>
      <App />
    </MockedProvider>,
  )

  await act(async () => await new Promise((resolve) => setTimeout(resolve, 0)))

  const domPiece = screen.getByText('C# In Depth, Fourth Edition - 978-1617294532')
  expect(domPiece).toBeInTheDocument()
})

it('renders error state', async () => {
  render(
    <MockedProvider mocks={errMocks}>
      <App />
    </MockedProvider>,
  )

  await act(async () => await new Promise((resolve) => setTimeout(resolve, 0)))

  const domPiece = screen.getByText('Error!')
  expect(domPiece).toBeInTheDocument()
})
