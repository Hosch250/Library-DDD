import App from './App'
import { createMockEnvironment, MockPayloadGenerator } from 'relay-test-utils'
import ReactTestRenderer from 'react-test-renderer'

test('Loading State', () => {
  const environment = createMockEnvironment()
  const renderer = ReactTestRenderer.create(
    <App environment={environment} />,
  )

  expect(
    renderer.root.find(node => node.children[0] === 'Loading...'),
  ).toBeDefined()
})

test('Data Render', () => {
  const environment = createMockEnvironment()
  const renderer = ReactTestRenderer.create(
    <App environment={environment} />,
  )

  ReactTestRenderer.act(() => {
    environment.mock.resolveMostRecentOperation(operation =>
      MockPayloadGenerator.generate(operation),
    )
  })

  expect(
    renderer.root.find(node => node.props.className === 'BooksPage'),
  ).toBeDefined()
})

test('Error State', () => {
  const environment = createMockEnvironment()
  const renderer = ReactTestRenderer.create(
    <App environment={environment} />,
  )

  ReactTestRenderer.act(() => {
    environment.mock.rejectMostRecentOperation(new Error('Uh-oh'))
  })

  expect(
    renderer.root.find(node => node.children[0] === 'Error!'),
  ).toBeDefined()
})