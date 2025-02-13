.PHONY: build-docs build-docs-website docs-local docs-local-docker

build-docs:
	@$(MAKE) build-docs-website

build-docs-website:
	mkdir -p dist
	docker build -t squidfunk/mkdocs-material ./docs/
	docker run --rm -t -v ${PWD}:/docs squidfunk/mkdocs-material build
	cp -R site/* dist/

docs-local:
	poetry run mkdocs serve

docs-local-docker:
	docker build -t squidfunk/mkdocs-material ./docs/
	docker run --rm -it -p 8000:8000 -v ${PWD}:/docs squidfunk/mkdocs-material