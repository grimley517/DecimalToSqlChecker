<!-- Managed by grimley517/pr-standards. Edit the "Repo notes" section only. -->
# Code review instructions

Review only the diff. Be terse: one comment per real problem, with file:line and a concrete fix. Skip praise, style nits and anything a linter catches. Deterministic CI already runs Semgrep OWASP rules, import-direction and coverage checks, so focus on what rules can't see.

## 1. Security (OWASP Top 10 2021), single pass
- A01 Broken access control: missing authz on new endpoints/handlers, IDOR (object IDs taken from input without an ownership check), CORS `*` with credentials, path traversal.
- A02 Crypto: secrets in code/config, weak hashing for passwords (anything other than bcrypt/scrypt/argon2), MD5/SHA1/ECB, disabled TLS verification, non-CSPRNG tokens.
- A03 Injection: string-built SQL/shell/LDAP/XPath/HTML, unescaped template output, `eval`/dynamic code.
- A04 Insecure design: missing rate limits, trust-boundary crossings, business rules enforced only client-side.
- A05 Misconfiguration: debug on, verbose errors to clients, permissive defaults, missing security headers.
- A06 Vulnerable components: new dependencies that are unpinned, abandoned or known-vulnerable.
- A07 AuthN: session fixation, missing expiry, credential stuffing exposure, plaintext credential handling.
- A08 Integrity: unsafe deserialisation, unsigned updates, CI steps pulling unpinned third-party actions/scripts.
- A09 Logging: security events (login, authz failure, admin action) not logged; secrets/PII written to logs.
- A10 SSRF: server-side fetches of user-supplied URLs without an allow-list.

## 2. Hexagonal architecture
- Business rules (validation, calculations, decisions, state transitions) must live in `domain/` or `application/`. Flag any business logic in controllers, handlers, CLI entry points, UI components, repositories/adapters, or scripts.
- Domain depends on nothing outward. Application depends on domain plus port interfaces only. Adapters implement ports and hold all IO (HTTP, DB, files, queues, clock, env).
- Flag framework types (HTTP request objects, ORM entities, SDK clients) leaking into domain/application signatures.

## 3. Tests
- New or changed domain/application behaviour needs unit tests covering the rule and its edge cases. Don't ask for tests of adapters, wiring or UI.
- Flag tests that only assert mocks were called, not outcomes.

## 4. Onboarding
- If the PR changes how to build, run, test or configure the project, the README and Makefile/package.json scripts (`make`/`npm run build`, `make run`/`npm run serve`, `make test`, `make coverage`) must be updated with it.

## Repo notes
